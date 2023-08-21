using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Logic
{
    public static class TroyanHorseDataAccess
    {
        public static List<TroyanHorse> GetTroyanHorses()
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "SELECT TroyanHorseId, StairCaseState, DoorState, Location FROM TroyanHorse;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            SQLiteDataReader reader = command.ExecuteReader();

            List<TroyanHorse> troyanHorses = new List<TroyanHorse>();

            while (reader.Read())
            {
                TroyanHorse troyanHorse = new TroyanHorse();
                troyanHorse.TroyanHorseId = reader.GetInt32(0);
                troyanHorse.StairCaseState = reader.GetString(1);
                troyanHorse.DoorState = reader.GetString(2);
                troyanHorse.Location = reader.GetString(3);

                troyanHorses.Add(troyanHorse);
            }

            ConnectionClass.connection.Close();

            return troyanHorses;
        }

        public static TroyanHorse GetTroyanHorse(int roomId)
        {
            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT TroyanHorseId, StairCaseState, DoorState, Location FROM TroyanHorse WHERE RoomId = @roomId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@roomId", roomId);
            SQLiteDataReader reader = command.ExecuteReader();

            TroyanHorse troyanHorse = new TroyanHorse();

            if (reader.Read())
            {
                troyanHorse.TroyanHorseId = reader.GetInt32(0);
                troyanHorse.StairCaseState = reader.GetString(1);
                troyanHorse.DoorState = reader.GetString(2);
                troyanHorse.Location = reader.GetString(3);
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return troyanHorse;
        }

        public static TroyanHorse GetTroyanHorseByTroyanHorseId(int troyanHorseId)
        {
            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT TroyanHorseId, StairCaseState, DoorState, Location FROM TroyanHorse WHERE TroyanHorseId = @troyanHorseId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@troyanHorseId", troyanHorseId);
            SQLiteDataReader reader = command.ExecuteReader();

            TroyanHorse troyanHorse = new TroyanHorse();

            if (reader.Read())
            {
                troyanHorse.TroyanHorseId = reader.GetInt32(0);
                troyanHorse.StairCaseState = reader.GetString(1);
                troyanHorse.DoorState = reader.GetString(2);
                troyanHorse.Location = reader.GetString(3);
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return troyanHorse;
        }

        public static int CreateTroyanHorse(TroyanHorse troyanHorse, int roomId)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "INSERT INTO TroyanHorse(RoomId, StairCaseState, DoorState, Location) " +
                    "VALUES(@roomId, @stairCaseState, @doorState, @location);";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@roomId", roomId);
            command.Parameters.AddWithValue("@stairCaseState", troyanHorse.StairCaseState);
            command.Parameters.AddWithValue("@doorState", troyanHorse.DoorState);
            command.Parameters.AddWithValue("@location", troyanHorse.Location);

            int newTroyanHorseId = Convert.ToInt32(command.ExecuteScalar());
            ConnectionClass.connection.Close();

            return newTroyanHorseId;
        }

        public static void UpdateTroyanHorse(int troyanHorseId, TroyanHorse troyanHorse)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "UPDATE TroyanHorse SET StairCaseState = @stairCaseState, DoorState = @doorState, Location = @location " +
                              "WHERE TroyanHorseId = @troyanHorseId;";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@stairCaseState", troyanHorse.StairCaseState);
            command.Parameters.AddWithValue("@doorState", troyanHorse.DoorState);
            command.Parameters.AddWithValue("@location", troyanHorse.Location);
            command.Parameters.AddWithValue("@troyanHorseId", troyanHorseId);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }

        public static void DeleteTroyanHorse(int troyanHorseId)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "DELETE FROM TroyanHorse WHERE TroyanHorseId = @troyanHorseId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@troyanHorseId", troyanHorseId);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }
    }
}
