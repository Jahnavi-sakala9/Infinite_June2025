using System;
using System.Data.SqlClient;

namespace MiniProject_RRS
{
    public class TrainRepo
    {
        public void Search(string src, string dst)
        {
            string sql = @"
                SELECT t.TrainId, t.TrainNo, t.TrainName, c.Class, c.TotalSeats, c.CostPerSeat
                FROM Trains t
                JOIN TrainClasses c ON t.TrainId = c.TrainId
                WHERE t.Source = @s AND t.Destination = @d
                ORDER BY t.TrainNo, c.Class;";

            SqlCommand cmd = Db.I.Cmd(sql);
            cmd.Parameters.AddWithValue("@s", src);
            cmd.Parameters.AddWithValue("@d", dst);

            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                Ui.TableHeader("TrainId", "No", "Name", "Class", "Seats", "Price");
                bool any = false;
                while (rd.Read())
                {
                    any = true;
                    Console.WriteLine(
                        string.Format("{0,7}  {1,-6}  {2,-18}  {3,-6}  {4,5}  {5,8}",
                        rd.GetInt32(0),
                        rd.GetString(1),
                        rd.GetString(2),
                        rd.GetString(3),
                        rd.GetInt32(4),
                        rd.GetDecimal(5)));
                }
                if (!any) Ui.Warn("No trains found for that route.");
            }
        }

        public bool AddTrain(string no, string name, string s, string d)
        {
            SqlCommand cmd = Db.I.Cmd(
                "INSERT INTO Trains(TrainNo, TrainName, Source, Destination) VALUES(@n, @nm, @s, @d)");
            cmd.Parameters.AddWithValue("@n", no);
            cmd.Parameters.AddWithValue("@nm", name);
            cmd.Parameters.AddWithValue("@s", s);
            cmd.Parameters.AddWithValue("@d", d);
            return cmd.ExecuteNonQuery() > 0;  // return bool so callers can say 'var ok = ...'
        }

        public void UpsertClass(int trainId, string classCode, int totalSeats, decimal price)
        {
            SqlCommand up = Db.I.Cmd(@"
                MERGE TrainClasses AS trg
                USING (SELECT @t AS TrainId, @c AS Class) AS src
                ON (trg.TrainId = src.TrainId AND trg.Class = src.Class)
                WHEN MATCHED THEN
                    UPDATE SET TotalSeats = @tot, CostPerSeat = @p
                WHEN NOT MATCHED THEN
                    INSERT (TrainId, Class, TotalSeats, CostPerSeat)
                    VALUES (@t, @c, @tot, @p);");

            up.Parameters.AddWithValue("@t", trainId);
            up.Parameters.AddWithValue("@c", classCode);
            up.Parameters.AddWithValue("@tot", totalSeats);
            up.Parameters.AddWithValue("@p", price);
            up.ExecuteNonQuery();

            Ui.Success("Class '" + classCode + "' set: seats=" + totalSeats + ", price=" + price);
        }
    }
}
