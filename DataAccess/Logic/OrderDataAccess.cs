using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Logic
{
    public static class OrderDataAccess
    {
        public static List<Order> GetOrdersOfCustomer(string username)
        {
            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();
            
            string sqlQuery = "SELECT FoodName, IssuedDate, QuantityOfFood, FinalPriceOfFood FROM [Order] " +
                              "WHERE UserUsername = @userUsername ORDER BY IssuedDate;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@userUsername", username);
            SQLiteDataReader reader = command.ExecuteReader();

            List<Order> orders = new List<Order>();

            Order order = null;
            while (reader.Read())
            {
                if(order == null || order.IssuedDate != DateTime.Parse(reader.GetString(1)))
                {
                    if(order != null) orders.Add(order);

                    order = new Order();
                    order.IssuedDate = DateTime.Parse(reader.GetString(1));
                    order.CustomerName = username;
                }
                order.FoodQuantities.Add(reader.GetString(0), reader.GetInt32(2));
                order.FinalPrice += reader.GetDouble(3);
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

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
                string sqlQuery = "INSERT INTO [Order](UserUsername, FoodName, IssuedDate, QuantityOfFood, FinalPriceOfFood) " +
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

        public static void CreateOrder(Order order)
        {
            ConnectionClass.connection.Open();
            foreach (Food food in order.Foods)
            {
                string sqlQuery = "INSERT INTO [Order](UserUsername, FoodName, IssuedDate, QuantityOfFood, FinalPriceOfFood) " +
                        "VALUES(@userUsername, @foodName, @issuedDate, @quantityOfFood, @finalPriceOfFood);";


                SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

                command.Parameters.AddWithValue("@userUsername", order.CustomerName);
                command.Parameters.AddWithValue("@foodName", food.FoodName);
                command.Parameters.AddWithValue("@issuedDate", order.IssuedDate);
                order.FoodQuantities.TryGetValue(food.FoodName,out int foodQuantity);
                command.Parameters.AddWithValue("@quantityOfFood", foodQuantity);
                command.Parameters.AddWithValue("@finalPriceOfFood", foodQuantity * food.PricePerUnit);
                command.ExecuteNonQuery();
            }

            ConnectionClass.connection.Close();
        }

        public static void DeleteOrdersOfCustomer(string userUsername)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "DELETE FROM [Order] WHERE UserUsername = @userUsername;";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@userUsername", userUsername);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }

        public static void DeleteOrder(string userUsername, DateTime issuedDate)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "DELETE FROM [Order] WHERE UserUsername = @userUsername AND IssuedDate = @issuedDate;";

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

            string sqlQuery = "SELECT FoodName, Price, FoodImage FROM Food;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            SQLiteDataReader reader = command.ExecuteReader();

            List<Food> foods = new List<Food>();

            if (reader.Read())
            {
                Food food = new Food();
                food.FoodName = reader.GetString(0);
                food.PricePerUnit = reader.GetDouble(1);
                food.FoodImage = reader.GetString(2);

                foods.Add(food);
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return foods;
        }


        public static Food GetFood(string foodName)
        {

            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT FoodName, Price, FoodImage FROM PoolAlert WHERE foodName = @foodName;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@foodName", foodName);
            SQLiteDataReader reader = command.ExecuteReader();

            Food food = new Food();

            if (reader.Read())
            {
                food.FoodName = reader.GetString(0);
                food.PricePerUnit = reader.GetDouble(1);
                food.FoodImage = reader.GetString(2);
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return food;
        }

        public static void CreateFood(Food food)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "INSERT INTO PoolAlert(FoodName, Price, FoodImage) " +
                 "VALUES(@foodName, @price, @foodImage);";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@foodName", food.FoodName);
            command.Parameters.AddWithValue("@price", food.PricePerUnit);
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
            string sqlQuery = "DELETE FROM [Order] WHERE FoodName = @foodName;" +
                              "DELETE FROM Food WHERE FoodName = @foodName;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@foodName", foodName);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }
    }
}
