using DataAccess.Models;
using DataAccess.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DataAccess.Logic
{
    public static class OrderDataAccess
    {
        public static List<Order> GetOrdersOfCustomer(string username)
        {
            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();
            
            string sqlQuery = "SELECT FoodName, IssuedDate, QuantityOfFood, FinalPriceOfFood FROM FoodOrder " +
                              "WHERE UserUsername = @userUsername ORDER BY IssuedDate;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@userUsername", username);
            SQLiteDataReader reader = command.ExecuteReader();

            List<OrderDataModel> ordersDataModels = new List<OrderDataModel>();
            while (reader.Read())
            {
                OrderDataModel ordersDataModel = new OrderDataModel();

                ordersDataModel.IssuedDate = DateTime.Parse(reader.GetString(1));
                ordersDataModel.FoodQuantities.Add(reader.GetString(0), reader.GetInt32(2));
                ordersDataModel.FinalPrice = reader.GetDouble(3);
                ordersDataModel.Foods.Add(GetFood(reader.GetString(0)));
                ordersDataModel.CustomerName = username;

                ordersDataModels.Add(ordersDataModel);
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            //think that is needed to fix the issue?
            //stupid database lock

            List<Order> orders = new List<Order>();
            Order order = null;
            foreach (OrderDataModel tempOrder in ordersDataModels)
            {
                //if the order is null or the order has a different issued date than the previous one it is a different order
                if (order == null || tempOrder.IssuedDate != order.IssuedDate)
                {
                    if(order != null)
                        orders.Add(order);
                    order = new Order();
                    order.IssuedDate = tempOrder.IssuedDate;
                    order.CustomerName = tempOrder.CustomerName;
                }
                order.FoodQuantities.Add(tempOrder.FoodQuantities.FirstOrDefault().Key, tempOrder.FoodQuantities.FirstOrDefault().Value);
                order.FinalPrice += tempOrder.FinalPrice;
                order.Foods.Add(tempOrder.Foods.FirstOrDefault());
            }
            //this is used for the last order. If the user had no orders skip that step.
            if (order != null)
                orders.Add(order);

            return orders;
        }

        public static List<Order> GetAllCustomerOrders()
        {
            List<string> customerUsernames = UserDataAccess.GetCustomersUsernames();

            List<Order> orders = new List<Order>();
            foreach (string customerUsername in customerUsernames)
            {
                orders.AddRange(GetOrdersOfCustomer(customerUsername));
            }

            return orders;
        }

        public static void CreateOrderUsingFoods(List<Food> foods,int quantity, string username)
        {
            ConnectionClass.connection.Open();
            foreach (Food food in foods)
            {
                string sqlQuery = "INSERT INTO FoodOrder(UserUsername, FoodName, IssuedDate, QuantityOfFood, FinalPriceOfFood) " +
                "VALUES(@userUsername, @foodName, @issuedDate, @quantityOfFood, @finalPriceOfFood);";

                
                SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

                command.Parameters.AddWithValue("@userUsername", username);
                command.Parameters.AddWithValue("@foodName", food.FoodName);
                command.Parameters.AddWithValue("@issuedDate", DateTime.Now.ToString());
                command.Parameters.AddWithValue("@quantityOfFood", quantity);
                command.Parameters.AddWithValue("@finalPriceOfFood", quantity * food.PricePerUnit);
                command.ExecuteNonQuery();
            }

            ConnectionClass.connection.Close();
        }

        public static bool CreateOrder(Order order)
        {
            try
            {
                ConnectionClass.connection.Open();

                // Create a single INSERT statement with multiple rows of values
                StringBuilder sqlQuery = new StringBuilder("INSERT INTO FoodOrder(UserUsername, FoodName, IssuedDate, QuantityOfFood, FinalPriceOfFood) VALUES ");

                using (SQLiteCommand command = new SQLiteCommand(ConnectionClass.connection))
                {
                    command.CommandTimeout = 5;
                    int parameterCount = 0; // Counter for parameter names

                    foreach (Food food in order.Foods)
                    {
                        if (parameterCount > 0)
                        {
                            sqlQuery.Append(", ");
                        }

                        sqlQuery.Append(
                            $"(@userUsername{parameterCount}, @foodName{parameterCount}, @issuedDate{parameterCount}, " +
                            $"@quantityOfFood{parameterCount}, @finalPriceOfFood{parameterCount})");

                        command.Parameters.AddWithValue($"@userUsername{parameterCount}", order.CustomerName);
                        command.Parameters.AddWithValue($"@foodName{parameterCount}", food.FoodName);
                        command.Parameters.AddWithValue($"@issuedDate{parameterCount}", order.IssuedDate.ToString());
                        order.FoodQuantities.TryGetValue(food.FoodName, out int foodQuantity);
                        command.Parameters.AddWithValue($"@quantityOfFood{parameterCount}", foodQuantity);
                        command.Parameters.AddWithValue($"@finalPriceOfFood{parameterCount}", foodQuantity * food.PricePerUnit);

                        parameterCount++;
                    }

                    // Append the SQL query with all rows and execute it
                    command.CommandText = sqlQuery.ToString();
                    command.ExecuteNonQuery();
                }

                ConnectionClass.connection.Close();
                return true; // Success
            }
            catch (SQLiteException)
            {
                //this is for the stupid database locked error
                ConnectionClass.connection.Close();
                return false; 
            }
        }

        public static void DeleteOrdersOfCustomer(string userUsername)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "DELETE FROM FoodOrder WHERE UserUsername = @userUsername;";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@userUsername", userUsername);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }

        public static void DeleteOrder(string userUsername, DateTime issuedDate)
        {
            ConnectionClass.connection.Open();

            string sqlQuery = "DELETE FROM FoodOrder WHERE UserUsername = @userUsername AND IssuedDate = @issuedDate;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@userUsername", userUsername);
            command.Parameters.AddWithValue("@issuedDate", issuedDate.ToString());

            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }


        ////////////////////////////// Food Stuff /////////////////////////////////

        public static List<Food> GetFoods()
        {

            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT FoodName, Price, Category, Description, PreparationTime, FoodImage FROM Food;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            SQLiteDataReader reader = command.ExecuteReader();

            List<Food> foods = new List<Food>();

            while (reader.Read())
            {
                Food food = new Food();
                food.FoodName = reader.GetString(0);
                food.PricePerUnit = reader.GetDouble(1);
                food.Category = reader.GetString(2);
                food.Description = reader.GetString(3);
                food.PreparationTime = reader.GetInt32(4);
                food.FoodImage = reader.GetString(5);

                foods.Add(food);
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return foods;
        }


        public static Food GetFood(string foodName)
        {

            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT FoodName, Price, Category, Description, PreparationTime, FoodImage FROM Food WHERE foodName = @foodName;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@foodName", foodName);
            SQLiteDataReader reader = command.ExecuteReader();

            Food food = new Food();

            if (reader.Read())
            {
                food.FoodName = reader.GetString(0);
                food.PricePerUnit = reader.GetDouble(1);
                food.Category = reader.GetString(2);
                food.Description = reader.GetString(3);
                food.PreparationTime = reader.GetInt32(4);
                food.FoodImage = reader.GetString(5);
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return food;
        }

        public static void CreateFood(Food food)
        {
            ConnectionClass.connection.Close();
            ConnectionClass.connection.Open();
            string sqlQuery = "INSERT INTO Food(FoodName, Price, Category, Description, PreparationTime, FoodImage) " +
                    "VALUES(@foodName, @price, @category, @description, @preparationTime, @foodImage);";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@foodName", food.FoodName);
            command.Parameters.AddWithValue("@price", food.PricePerUnit);
            command.Parameters.AddWithValue("@category", food.Category);
            command.Parameters.AddWithValue("@description", food.Description);
            command.Parameters.AddWithValue("@preparationTime", food.PreparationTime);
            command.Parameters.AddWithValue("@foodImage", food.FoodImage);

            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }

        //TODO think about that, because updating the name of the username must also update the orders
        public static void UpdateFood(Food food)
        {
            
        }

        public static void DeleteFood(string foodName)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "DELETE FROM FoodOrder WHERE FoodName = @foodName;" +
                              "DELETE FROM Food WHERE FoodName = @foodName;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@foodName", foodName);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }
    }
}
