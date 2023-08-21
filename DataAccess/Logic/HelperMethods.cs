using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Logic
{
    internal static class HelperMethods
    {
        public static bool CheckConnectionAndOpenIfNecessary()
        {
            if (ConnectionClass.connection.State != ConnectionState.Open)
            {
                ConnectionClass.connection.Open();
                return true;
            }
            return false;
        }

        public static void CloseConnectionOrDoNothing(bool shouldClose)
        {
            if (shouldClose)
            {
                ConnectionClass.connection.Close();
            }
        }


    }
}
