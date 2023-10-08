using DataAccess.Models;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DataAccess.Logic
{
    public static class UserDataAccess
    {
        public static (User, string) GetUser(string username)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "SELECT Username, Password, Email, Phone, RecoveryQuestion, RecoveryAnswer, UserType FROM User WHERE Username = @username;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@username", username);
            SQLiteDataReader reader = command.ExecuteReader();

            Customer customer = null;
            Employee employee = null;
            if (reader.Read())
            {
                //fix the orders
                if (reader.GetString(6) == "Customer")
                {
                    customer = new Customer();
                    customer.Username = reader.GetString(0);
                    customer.Password = reader.GetString(1);
                    customer.Email = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                    customer.Phone = !reader.IsDBNull(3) ? reader.GetString(3) : "";
                    customer.RecoveryQuestion = reader.GetString(4);
                    customer.RecoveryAnswer = reader.GetString(5);
                    customer.Room = RoomDataAccess.GetRoom(reader.GetString(0));
                    customer.Orders = OrderDataAccess.GetOrdersOfCustomer(reader.GetString(0));
                }
                else
                {
                    employee = new Employee();
                    employee.Username = reader.GetString(0);
                    employee.Password = reader.GetString(1);
                    employee.Email = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                    employee.Phone = !reader.IsDBNull(3) ? reader.GetString(3) : "";
                    employee.RecoveryQuestion = reader.GetString(4);
                    employee.RecoveryAnswer = reader.GetString(5);
                    employee.Rooms = RoomDataAccess.GetRooms();
                    employee.Orders = OrderDataAccess.GetAllCustomerOrders();
                }
            }
            ConnectionClass.connection.Close();

            if (customer == null)
                return (employee, "Employee");
            return (customer, "Customer");
        }

        public static string CheckTypeOfUser(string username)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "SELECT UserType FROM User WHERE Username = @username;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@username", username);
            SQLiteDataReader reader = command.ExecuteReader();

            string userType = "";
            if (reader.Read())
            {
                userType = reader.GetString(0);
            }

            ConnectionClass.connection.Close();
            return userType;
        }

        public static List<string> GetCustomersUsernames()
        {
            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();
            //ConnectionClass.connection.Open();
            string sqlQuery = "SELECT Username FROM User WHERE UserType = 'Customer';";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            SQLiteDataReader reader = command.ExecuteReader();
            
            List<string> usernames = new List<string>();
            while (reader.Read())
            {
                usernames.Add(reader.GetString(0));
            }
            HelperMethods.CloseConnectionOrDoNothing(shouldClose);
            //ConnectionClass.connection.Close();

            return usernames;
        }

        public static bool CreateUser(User user)
        {
            //there was another user with the same username
            if (GetUser(user.Username).Item1 != null)
            {
                return false;
            }
            //there is no other user with the same username and we can continue
            ConnectionClass.connection.Open();
            string sqlQuery = "INSERT INTO User(Username, Password, Email, Phone, RecoveryQuestion, RecoveryAnswer, UserType) " +
                "VALUES(@username, @password , @email, @phone, @recoveryQuestion, @recoveryAnswer, @userType);";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@phone", user.Phone);
            command.Parameters.AddWithValue("@recoveryQuestion", user.RecoveryQuestion);
            command.Parameters.AddWithValue("@recoveryAnswer", user.RecoveryAnswer);
            if(user.GetType() == typeof(Customer))
            {
                command.Parameters.AddWithValue("@userType", "Customer");
            }
            else
            {
                command.Parameters.AddWithValue("@userType", "Employee");
            }
            command.ExecuteNonQuery();
            ConnectionClass.connection.Close();

            return true;
        }

        public static void UpdateUser(User user)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "UPDATE User " +
                "SET Password = @password, Email = @email, Phone = @phone " +
                "RecoveryQuestion = @recoveryQuestion, RecoveryAnswer = recoveryAnswer " +
                "WHERE Username = @username;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@phone", user.Phone);
            command.Parameters.AddWithValue("@recoveryQuestion", user.RecoveryQuestion);
            command.Parameters.AddWithValue("@recoveryAnswer", user.RecoveryAnswer);
            command.ExecuteNonQuery();
            ConnectionClass.connection.Close();
        }

        //TODO this does not work
        public static bool UpdateUserAndUsername(User user, string oldUsername)
        {
            //there is another user with the same username
            if (GetUser(user.Username).Item1 != null)
            {
                return false;
            }
            //there is no other user with the same username and we can update to that username
            ConnectionClass.connection.Open();
            string sqlQuery = "UPDATE User " +
                "SET Username = @username, Password = @password, " +
                "RecoveryQuestion = @recoveryQuestion, RecoveryAnswer = @recoveryAnswer " +
                "WHERE Username = @oldUsername;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@recoveryQuestion", user.RecoveryQuestion);
            command.Parameters.AddWithValue("@recoveryAnswer", user.RecoveryAnswer);
            command.Parameters.AddWithValue("@oldUsername", oldUsername);
            command.ExecuteNonQuery();
            ConnectionClass.connection.Close();

            return true;
        }

        public static void DeleteUser(string username)
        {
            //first remove the user from the room
            RoomDataAccess.RemoveUserFromRoom(username);

            //then delete any order that the user participates in and then delete the user
            ConnectionClass.connection.Open();
            string sqlQuery = "DELETE FROM FoodOrder WHERE UserUsername = @username;" +
                              "DELETE FROM User WHERE Username = @username;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@username", username);
            command.ExecuteNonQuery();
            ConnectionClass.connection.Close();
        }
    }
}
