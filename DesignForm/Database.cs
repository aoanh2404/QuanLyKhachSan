using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignForm
{
   public static class Database
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"DESKTOP-O9T6LT5\SQLEXPRESS";

            string database = "QLKS";
            string username = "sa";
            string password = "khaun";

            string connString = @"Data Source=" + datasource + ";Initial Catalog="
            + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}

