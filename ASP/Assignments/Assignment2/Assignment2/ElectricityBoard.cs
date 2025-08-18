using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Assignment2
{
    public class ElectricityBoard
    {
        private readonly DBHandler _db = new DBHandler();

        public void CalculateBill(ElectricityBill ebill)
        {

            int u = ebill.UnitsConsumed;
            double amt = 0;
            int rem = u;

            int s1 = Math.Min(rem, 100); rem -= s1;

            if (rem > 0) { int s2 = Math.Min(rem, 200); amt += s2 * 1.5; rem -= s2; }
            if (rem > 0) { int s3 = Math.Min(rem, 300); amt += s3 * 3.5; rem -= s3; }
            if (rem > 0) { int s4 = Math.Min(rem, 400); amt += s4 * 5.5; rem -= s4; }
            if (rem > 0) { amt += rem * 7.5; }

            ebill.BillAmount = amt;
        }

        public void AddBill(ElectricityBill ebill)
        {
            using (var con = _db.GetConnection())
            using (var cmd = new SqlCommand(@"
                INSERT INTO dbo.ElectricityBill
                (consumer_number, consumer_name, units_consumed, bill_amount)
                VALUES (@cn, @name, @units, @amount);", con))
            {
                cmd.Parameters.AddWithValue("@cn", ebill.ConsumerNumber);
                cmd.Parameters.AddWithValue("@name", ebill.ConsumerName);
                cmd.Parameters.AddWithValue("@units", ebill.UnitsConsumed);
                cmd.Parameters.AddWithValue("@amount", ebill.BillAmount);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            var list = new List<ElectricityBill>();
            using (var con = _db.GetConnection())
            using (var cmd = new SqlCommand(@"
                SELECT TOP (@n) consumer_number, consumer_name, units_consumed, bill_amount
                FROM dbo.ElectricityBill
                ORDER BY id DESC;", con))
            {
                cmd.Parameters.Add("@n", SqlDbType.Int).Value = num;
                con.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new ElectricityBill
                        {
                            ConsumerNumber = r.GetString(0),
                            ConsumerName = r.GetString(1),
                            UnitsConsumed = r.GetInt32(2),
                            BillAmount = Convert.ToDouble(r.GetDouble(3))
                        });
                    }
                }
            }
            return list;
        }
    }
}
