using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Code_Challenge_6
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    namespace ConnectedADO
    {
        //First program 
        class Program
        {
            public static SqlConnection con;
            public static SqlCommand cmd;

            static void Main(string[] args)
            {
                InsertData(); // calling insert using stored procedure
                Console.ReadLine();
            }

            // common method to open connection
            static SqlConnection getConnection()
            {
                con = new SqlConnection("Data Source= ICS-LT-1YX9J84\\SQLEXPRESS; Initial Catalog=Assesments;" +
                "user id=sa; password=Sakalajahnavi@123;");
                con.Open();
                return con;
            }

            static void InsertData()
            {
                try
                {
                    con = getConnection();

                    Console.WriteLine("Enter Employee Name:");
                    string empname = Console.ReadLine();

                    Console.WriteLine("Enter Gender (M/F):");
                    string gender = Console.ReadLine();

                    Console.WriteLine("Enter Given Salary:");
                    decimal givensalary = Convert.ToDecimal(Console.ReadLine());

                    // setting up the command
                    cmd = new SqlCommand("insert_employee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // input parameters
                    cmd.Parameters.AddWithValue("@name", empname);
                    cmd.Parameters.AddWithValue("@givensalary", givensalary);
                    cmd.Parameters.AddWithValue("@gender", gender);

                    // output parameters with SqlDbType defined
                    SqlParameter outEmpId = new SqlParameter("@generatedempid", SqlDbType.Int);
                    outEmpId.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outEmpId);

                    SqlParameter outSalary = new SqlParameter("@calculatedsalary", SqlDbType.Decimal);
                    outSalary.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outSalary);

                    // execute the procedure
                    cmd.ExecuteNonQuery();

                    // display results
                    Console.WriteLine("\nEmployee Record Inserted Successfully!");
                    Console.WriteLine("Generated EmpId     : " + outEmpId.Value);
                    Console.WriteLine("Calculated Net Salary: " + outSalary.Value);
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                }
            }
        }
    }
}
