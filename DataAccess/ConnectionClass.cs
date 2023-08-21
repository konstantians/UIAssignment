using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal class ConnectionClass
    {
        internal static SQLiteConnection connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
    }
}
