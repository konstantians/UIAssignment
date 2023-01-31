using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessOperations
    {
        private static string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private static SQLiteConnection connection = new SQLiteConnection(ConnectionString);

        public static List<User> GetUsers()
        {
            connection.Open();
            string sqlQuery = "Select * from Employee";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                User user = new User();

                user.Username = reader.GetString(0);
                user.Password = reader.GetString(1);
                user.RecoveryQuestion = reader.GetString(2);
                user.RecoveryAnswer = reader.GetString(3);
                user.UserRole = reader.GetString(4);

                users.Add(user);
            }
            connection.Close();

            return users;
        }

        public static User GetUser(string username)
        {
            connection.Open();
            string sqlQuery = $"Select * from User where Username = '{username}'";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            User user = new User();

            while (reader.Read())
            {
                user.Username = reader.GetString(0);
                user.Password = reader.GetString(1);
                user.RecoveryQuestion = reader.GetString(2);
                user.RecoveryAnswer = reader.GetString(3);
                user.UserRole = reader.GetString(4);
            }
            connection.Close();

            return user;
        }

        public static User CreateUser(User user)
        {
            //there was another user with the same username
            if (GetUser(user.Username).Username != null)
            {
                return null;
            }
            //there is no other user with the same username and we can continue
            connection.Open();
            string sqlQuery = $"Insert into User(Username,Password,RecoveryQuestion," +
                $"RecoveryAnswer,UserRole) values('{user.Username}','{user.Password}'," +
                $"'{user.RecoveryQuestion}','{user.RecoveryAnswer}','{user.UserRole}')";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection);
            command.ExecuteNonQuery();
            connection.Close();
            return user;
        }

        public static void DeleteUser(string username)
        {
            connection.Open();
            string sqlQuery = $"Delete from User where Username = '{username}'";  
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateUser(User user)
        {
            connection.Open();
            string sqlQuery = $"Update User" +
                $" set Password = '{user.Password}',RecoveryQuestion = '{user.RecoveryQuestion}', " +
                $"RecoveryAnswer = '{user.RecoveryAnswer}', UserRole = '{user.UserRole}' " +
                $"where Username = '{user.Username}'";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static bool UpdateUserAndUsername(User user,string oldUsername)
        {
            //there is another user with the same username
            if(GetUser(user.Username).Username != null)
            {
                return false;
            }
            //there is no other user with the same username and we can update to that username
            connection.Open();
            string sqlQuery = $"Update User" +
                $" set Username = '{user.Username}',Password = '{user.Password}'," +
                $"RecoveryQuestion = '{user.RecoveryQuestion}', " +
                $"RecoveryAnswer = '{user.RecoveryAnswer}', UserRole = '{user.UserRole}' " +
                $"where Username = '{oldUsername}'";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, connection);
            command.ExecuteNonQuery();
            connection.Close();

            return true;
        }
    }
}
