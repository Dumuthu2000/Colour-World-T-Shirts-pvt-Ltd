using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Colour_World__T_Shirts__pvt___Ltd
{
    internal class connectionSql
    {
        private string connectionString = "Data Source=DESKTOP-BCB35Q8\\SQLEXPRESS;Initial Catalog=colourWorldTshirtsProject;Integrated Security=True";
        public SqlConnection connSql()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}
