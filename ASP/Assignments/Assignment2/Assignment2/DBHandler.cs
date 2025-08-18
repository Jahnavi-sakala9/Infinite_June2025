using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace Assignment2
{
    public class DBHandler
    {
        public SqlConnection GetConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}
