using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DataAccess.Logic
{
    public static class RoomDataAccess
    {
        
        public static List<Room> GetRooms()
        {
            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();
            //ConnectionClass.connection.Open();
            string sqlQuery = "SELECT RoomId, RoomTemperature, RoomLighting FROM Room;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            SQLiteDataReader reader = command.ExecuteReader();

            List<Room> rooms = new List<Room>();

            while (reader.Read())
            {
                Room room = new Room();
                room.Pool = PoolDataAccess.GetPool(reader.GetInt32(0));
                room.TroyanHorse = TroyanHorseDataAccess.GetTroyanHorse(reader.GetInt32(0));
                room.Radio = GetRadio(reader.GetInt32(0));
                room.Television = GetTelevision(reader.GetInt32(0));
                room.RoomId = reader.GetInt32(0);
                room.RoomTemperature = reader.GetInt32(1);
                room.RoomLighting = reader.GetInt32(2);

                rooms.Add(room);
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);
            //ConnectionClass.connection.Close();

            return rooms;
        }

        //TODO fix that after radio
        public static Room GetRoom(string userUsername)
        {
            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT RoomId, RoomTemperature, RoomLighting FROM Room WHERE UserUsername = @userUsername;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@userUsername", userUsername);
            SQLiteDataReader reader = command.ExecuteReader();

            Room room = new Room();

            if (reader.Read())
            {
                room.Pool = PoolDataAccess.GetPool(reader.GetInt32(0));
                room.TroyanHorse = TroyanHorseDataAccess.GetTroyanHorse(reader.GetInt32(0));
                room.Radio = GetRadio(reader.GetInt32(0));
                room.Television = GetTelevision(reader.GetInt32(0));
                room.RoomId = reader.GetInt32(0);
                room.RoomTemperature = reader.GetInt32(1);
                room.RoomLighting = reader.GetInt32(2);
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return room;
        }

        public static Room GetRoomByRoomId(int roomId)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "SELECT RoomId, RoomTemperature, RoomLighting FROM Room WHERE RoomId = @roomId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@roomId", roomId);
            SQLiteDataReader reader = command.ExecuteReader();

            Room room = new Room();

            if (reader.Read())
            {
                room.Pool = PoolDataAccess.GetPool(reader.GetInt32(0));
                room.TroyanHorse = TroyanHorseDataAccess.GetTroyanHorse(reader.GetInt32(0));
                room.Radio = GetRadio(reader.GetInt32(0));
                room.Television = GetTelevision(reader.GetInt32(0));
                room.RoomId = reader.GetInt32(0);
                room.RoomTemperature = reader.GetInt32(1);
                room.RoomLighting = reader.GetInt32(2);
            }

            ConnectionClass.connection.Close();

            return room;
        }

        public static int CreateRoom(Room room, string userUsername)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "INSERT INTO Room(UserUsername, RoomTemperature, RoomLighting) " +
                "VALUES(@userUsername, @roomTemperature, @roomLighting);";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@userUsername", userUsername);
            command.Parameters.AddWithValue("@roomTemperature", room.RoomTemperature);
            command.Parameters.AddWithValue("@roomLighting", room.RoomLighting);

            int newRoomId = Convert.ToInt32(command.ExecuteScalar());
            ConnectionClass.connection.Close();

            return newRoomId;
        }

        public static void UpdateRoom(Room room)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "UPDATE Room SET RoomTemperature = @roomTemperature, RoomLighting = @roomLighting " +
                "WHERE RoomId = @roomId;";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@roomId", room.RoomId);
            command.Parameters.AddWithValue("@roomTemperature", room.RoomTemperature);
            command.Parameters.AddWithValue("@roomLighting", room.RoomLighting);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }

        //TODO add a check for limit
        public static bool ConnectUserToRoom(string username)
        {
            ConnectionClass.connection.Open();

            //find an empty room
            string sqlQuery = "SELECT RoomId FROM Room WHERE UserUsername IS NULL ORDER BY RoomId LIMIT 1;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            SQLiteDataReader reader = command.ExecuteReader();

            int roomId = 0;
            if (reader.Read())
            {
                roomId = reader.GetInt32(0);
            }

            //if there is no room available return false
            if (roomId == 0)
                return false;

            //otherwise connect user to room
            sqlQuery = "UPDATE Room SET UserUsername = @userUsername WHERE RoomId = @roomId;";
            command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@userUsername", username);
            command.Parameters.AddWithValue("@roomId", roomId);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();

            return true;
        }

        public static void RemoveUserFromRoom(string userUsername)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "UPDATE Room SET UserUsername = NULL WHERE UserUsername = @userUsername;";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@userUsername", userUsername);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }

        public static void DeleteRoom(int roomId)
        {
            //first delete everything that is attached to it and then delete the room
            TroyanHorseDataAccess.DeleteTroyanHorse(TroyanHorseDataAccess.GetTroyanHorse(roomId).TroyanHorseId);
            PoolDataAccess.DeletePool(PoolDataAccess.GetPool(roomId).PoolId);
            DeleteRadio(GetRadio(roomId).RadioId);
            DeleteTelevision(GetTelevision(roomId).TelevisionId);
            
            ConnectionClass.connection.Open();

            string sqlQuery = "DELETE FROM Room WHERE RoomId = @roomId;";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@roomId", roomId);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }

        /////////////////////////// Radio Stuff ///////////////////////////
        public static Radio GetRadio(int roomId)
        {
            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT RadioId, RadioSong, RadioVolume, IsRadioOn FROM Radio WHERE RoomId = @roomId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@roomId", roomId);
            SQLiteDataReader reader = command.ExecuteReader();

            Radio radio = new Radio();

            if (reader.Read())
            {
                radio.RadioId = reader.GetInt32(0);
                radio.RadioSong = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                radio.RadioVolume = reader.GetInt32(2);
                radio.IsRadioOn = Convert.ToBoolean(reader.GetInt32(3));
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return radio;
        }

        public static Radio GetRadioByRadioId(int radioId)
        {
            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT RadioId, RadioSong, RadioVolume, IsRadioOn FROM Radio WHERE RadioId = @radioId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@radioId", radioId);
            SQLiteDataReader reader = command.ExecuteReader();

            Radio radio = new Radio();

            if (reader.Read())
            {
                radio.RadioId = reader.GetInt32(0);
                radio.RadioSong = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                radio.RadioVolume = reader.GetInt32(2);
                radio.IsRadioOn = Convert.ToBoolean(reader.GetInt32(3));
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return radio;
        }

        public static int CreateRadio(Radio radio, int roomId)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "INSERT INTO Radio(RoomId, RadioSong, RadioVolume, IsRadioOn) " +
                "VALUES(@roomId, @radioSong, @radioVolume, @isRadioOn);";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@roomId", roomId);
            command.Parameters.AddWithValue("@radioSong", radio.RadioSong);
            command.Parameters.AddWithValue("@radioVolume", radio.RadioVolume);
            command.Parameters.AddWithValue("@isRadioOn", radio.IsRadioOn);

            int newRadioId = Convert.ToInt32(command.ExecuteScalar());
            ConnectionClass.connection.Close();

            return newRadioId;
        }

        public static void UpdateRadio(int radioId, Radio radio)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "UPDATE Radio SET RadioSong = @radioSong, RadioVolume = @radioVolume, IsRadioOn = @isRadioOn " +
                "WHERE RadioId = @radioId;";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@radioSong", radio.RadioSong);
            command.Parameters.AddWithValue("@radioVolume", radio.RadioVolume);
            command.Parameters.AddWithValue("@isRadioOn", radio.IsRadioOn);
            command.Parameters.AddWithValue("@radioId", radioId);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }

        public static void DeleteRadio(int radioId)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "DELETE FROM Radio WHERE RadioId = @radioId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@RadioId", radioId);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }

        /////////////////////////// Television Stuff ///////////////////////////
        public static Television GetTelevision(int roomId)
        {
            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT TelevisionId, TelevisionProgram, TelevisionVolume, IsTelevisionOn FROM Television WHERE RoomId = @roomId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@roomId", roomId);
            SQLiteDataReader reader = command.ExecuteReader();

            Television television = new Television();

            if (reader.Read())
            {
                television.TelevisionId = reader.GetInt32(0);
                television.TelevisionProgram = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                television.TelevisionVolume = reader.GetInt32(2);
                television.IsTelevisionOn = Convert.ToBoolean(reader.GetInt32(3));
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return television;
        }

        public static Television GetTelevisionByTelevisionId(int televisionId)
        {
            bool shouldClose = HelperMethods.CheckConnectionAndOpenIfNecessary();

            string sqlQuery = "SELECT TelevisionId, TelevisionProgram, TelevisionVolume, IsTelevisionOn FROM Television WHERE TelevisionId = @televisionId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@televisionId", televisionId);
            SQLiteDataReader reader = command.ExecuteReader();

            Television television = new Television();

            if (reader.Read())
            {
                television.TelevisionId = reader.GetInt32(0);
                television.TelevisionProgram = !reader.IsDBNull(1) ? reader.GetString(1) : "";
                television.TelevisionVolume = reader.GetInt32(2);
                television.IsTelevisionOn = Convert.ToBoolean(reader.GetInt32(3));
            }

            HelperMethods.CloseConnectionOrDoNothing(shouldClose);

            return television;
        }

        public static int CreateTelevision(Television television, int roomId)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "INSERT INTO Television(RoomId, TelevisionProgram, TelevisionVolume, IsTelevisionOn) " +
                "VALUES(@roomId, @televisionProgram, @televisionVolume, @isTelevisionOn);";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@roomId", roomId);
            command.Parameters.AddWithValue("@televisionProgram", television.TelevisionProgram);
            command.Parameters.AddWithValue("@televisionVolume", television.TelevisionVolume);
            command.Parameters.AddWithValue("@isTelevisionOn", television.IsTelevisionOn);

            int newRadioId = Convert.ToInt32(command.ExecuteScalar());
            ConnectionClass.connection.Close();

            return newRadioId;
        }

        public static void UpdateTelevision(int televisionId, Television television)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "UPDATE Television SET TelevisionProgram = @televisionProgram, TelevisionVolume = @televisionVolume, IsTelevisionOn = @isTelevisionOn " +
                "WHERE TelevisionId = @televisionId;";

            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@televisionProgram", television.TelevisionProgram);
            command.Parameters.AddWithValue("@televisionVolume", television.TelevisionVolume);
            command.Parameters.AddWithValue("@isTelevisionOn", television.IsTelevisionOn);
            command.Parameters.AddWithValue("@televisionId", televisionId);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }

        public static void DeleteTelevision(int televisionId)
        {
            ConnectionClass.connection.Open();
            string sqlQuery = "DELETE FROM Television WHERE TelevisionId = @televisionId;";
            SQLiteCommand command = new SQLiteCommand(sqlQuery, ConnectionClass.connection);

            command.Parameters.AddWithValue("@TelevisionId", televisionId);
            command.ExecuteNonQuery();

            ConnectionClass.connection.Close();
        }

    }
}
