using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Code_Challenge_6
{
    class UpdateEmployee
    {
        public static SqlConnection con;
        public static SqlCommand cmd;

        static void Main(string[] args)
        {
            UpdateSalaryUsingProcedure();
            Console.Read();
        }

        static SqlConnection getConnection()
        {
            con = new SqlConnection("Data Source=ICS-LT-1YX9J84\\SQLEXPRESS; Initial Catalog=Assesments; user id=sa; password=Sakalajahnavi@123;");
            con.Open();
            return con;
        }

        static void UpdateSalaryUsingProcedure()
        {
            try
            {
                con = getConnection();

                Console.Write("Enter Employee ID: ");
                int empid = Convert.ToInt32(Console.ReadLine());

                cmd = new SqlCommand("update_employee_salary", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Input
                cmd.Parameters.AddWithValue("@empid", empid);

                // Output parameters
                SqlParameter nameParam = new SqlParameter("@name", SqlDbType.VarChar, 100);
                nameParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(nameParam);

                SqlParameter genderParam = new SqlParameter("@gender", SqlDbType.Char, 1);
                genderParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(genderParam);

                SqlParameter updatedSalaryParam = new SqlParameter("@updated_salary", SqlDbType.Int);
                updatedSalaryParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(updatedSalaryParam);

                SqlParameter netSalaryParam = new SqlParameter("@net_salary", SqlDbType.Int);
                netSalaryParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(netSalaryParam);

                cmd.ExecuteNonQuery();

                // Display result
                Console.WriteLine("--- Updated Employee Details ---");
                Console.WriteLine("EmpId          : " + empid);
                Console.WriteLine("Name           : " + nameParam.Value);
                Console.WriteLine("Gender         : " + genderParam.Value);
                Console.WriteLine("Updated Salary : " + updatedSalaryParam.Value);
                Console.WriteLine("Net Salary     : " + netSalaryParam.Value);
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}




