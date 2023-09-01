using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DataAccess.Logic
{
    public static class PoolDataAccess
    {
        public static List<Pool> GetPools()
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "SELECT PoolId, PoolTemperature, WaterLevel FROM Pool;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            SQLiteDataReader reader = command.ExecuteReader();

            List<Pool> pools = new List<Pool>();

            while (reader.Read())
            {
                Pool pool = new Pool();
                pool.PoolId = reader.GetInt32(0);
                pool.PoolAlert = GetPoolAlert(reader.GetInt32(0));
                pool.PoolTemperature = reader.GetDouble(1);
                pool.WaterLevel = reader.GetInt32(2);

                pools.Add(pool);
            }

            ConnectionClass.connection.Close();

            return pools;
        }

        public static Pool GetPoolByPoolId(int poolId)
        {
            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT PoolId, PoolTemperature, WaterLevel FROM Pool WHERE PoolId = @poolId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@poolId", poolId);
            SQLiteDataReader reader = command.ExecuteReader();

            Pool pool = new Pool();

            if (reader.Read())
            {
                pool.PoolId = reader.GetInt32(0);
                pool.PoolAlert = GetPoolAlert(reader.GetInt32(0));
                pool.PoolTemperature = reader.GetDouble(1);
                pool.WaterLevel = reader.GetInt32(2);
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return pool;
        }

        public static Pool GetPool(int roomId)
        {
            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT PoolId, PoolTemperature, WaterLevel FROM Pool WHERE RoomId = @roomId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@roomId", roomId);
            SQLiteDataReader reader = command.ExecuteReader();

            Pool pool = new Pool();

            if (reader.Read())
            {
                pool.PoolId = reader.GetInt32(0);
                pool.PoolAlert = GetPoolAlert(reader.GetInt32(0));
                pool.PoolTemperature = reader.GetDouble(1);
                pool.WaterLevel = reader.GetInt32(2);
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return pool;
        }

        public static int CreatePool(Pool pool, int roomId)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "INSERT INTO Pool(RoomId, PoolTemperature, WaterLevel) " +
                "VALUES(@roomId, @poolTemperature, @waterLevel);";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@roomId", roomId);
            command.Parameters.AddWithValue("@poolTemperature", pool.PoolTemperature);
            command.Parameters.AddWithValue("@waterLavel", pool.WaterLevel);

            int newPoolId = Convert.ToInt32(command.ExecuteScalar());
            ConnectionClass.connection.Close();

            return newPoolId;
        }

        public static void UpdatePool(int poolId, Pool pool)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "UPDATE Pool SET PoolTemperature = @poolTemperature, WaterLevel = @waterLevel WHERE PoolId = @poolId;";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@poolId", poolId);
            command.Parameters.AddWithValue("@poolTemperature", pool.PoolTemperature);
            command.Parameters.AddWithValue("@waterLevel", pool.WaterLevel);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }

        public static void DeletePool(int poolId)
        {
            //first delete the pool alert
            //then delete the pool
            ConnectionClass.connection.Open();
            string sqlQuery = "DELETE FROM PoolAlert WHERE PoolId = @poolId;" +
                              "DELETE FROM Pool WHERE PoolId = @poolId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@poolId", poolId);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }


        ////////////////////////////// Pool Alert Stuff /////////////////////////////////

        public static PoolAlert GetPoolAlert(int poolId)
        {

            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT PoolAlertId, [From], Until, SoundTrack, IsPoolAlertOn FROM PoolAlert WHERE poolId = @poolId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@poolId", poolId);
            SQLiteDataReader reader = command.ExecuteReader();

            PoolAlert poolAlert = new PoolAlert();

            if (reader.Read())
            {
                poolAlert.PoolAlertId = reader.GetInt32(0);
                poolAlert.From = Convert.ToDateTime(reader.GetString(1));
                poolAlert.Until = Convert.ToDateTime(reader.GetString(2));
                poolAlert.SoundTrack = !reader.IsDBNull(3) ? reader.GetString(3) : "";
                poolAlert.IsPoolAlertOn = Convert.ToBoolean(reader.GetInt32(4));
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return poolAlert;
        }

        public static PoolAlert GetPoolAlertByPoolAlertId(int poolAlertId)
        {

            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT PoolAlertId, [From], Until, SoundTrack, IsPoolAlertOn FROM PoolAlert WHERE PoolAlertId = @poolAlertId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@poolAlertId", poolAlertId);
            SQLiteDataReader reader = command.ExecuteReader();

            PoolAlert poolAlert = new PoolAlert();

            if (reader.Read())
            {
                poolAlert.PoolAlertId = reader.GetInt32(0);
                poolAlert.From = Convert.ToDateTime(reader.GetString(1));
                poolAlert.Until = Convert.ToDateTime(reader.GetString(2));
                poolAlert.SoundTrack = !reader.IsDBNull(3) ? reader.GetString(3) : "";
                poolAlert.IsPoolAlertOn = Convert.ToBoolean(reader.GetInt32(4));
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return poolAlert;
        }

        public static int CreatePoolAlert(PoolAlert poolAlert, int poolId)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "INSERT INTO PoolAlert(PoolId, [From], Until, SoundTrack, IsPoolAlertOn) " +
                              "VALUES(@poolId, @from, @until, @soundTrack, 0);";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@poolId", poolId);
            command.Parameters.AddWithValue("@from", Convert.ToString(poolAlert.From));
            command.Parameters.AddWithValue("@until", Convert.ToString(poolAlert.Until));
            command.Parameters.AddWithValue("@soundTrack", poolAlert.SoundTrack);

            int newAlertId = Convert.ToInt32(command.ExecuteScalar());
            ConnectionClass.connection.Close();

            return newAlertId;
        }

        public static void UpdatePoolAlert(PoolAlert poolAlert)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "UPDATE PoolAlert SET [From] = @from, Until = @until, SoundTrack = @soundTrack, IsPoolAlertOn = @isPoolAlertOn " +
                              "WHERE PoolAlertId = @poolAlertId;";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@poolAlertId", poolAlert.PoolAlertId);
            command.Parameters.AddWithValue("@from", Convert.ToString(poolAlert.From));
            command.Parameters.AddWithValue("@until", Convert.ToString(poolAlert.Until));
            command.Parameters.AddWithValue("@soundTrack", poolAlert.SoundTrack);
            command.Parameters.AddWithValue("@isPoolAlertOn", Convert.ToInt32(poolAlert.IsPoolAlertOn));
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }

        public static void DeletePoolAlert(int poolAlertId)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "DELETE FROM PoolAlert WHERE PoolAlertId = @poolAlertId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@poolAlertId", poolAlertId);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }
    }
}
