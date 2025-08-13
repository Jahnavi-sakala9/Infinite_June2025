using System;
using System.Data.SqlClient;

namespace MiniProject_RRS
{
    public class BookingRepo
    {
        public void MyBookings(int uid)
        {
            SqlCommand cmd = Db.I.Cmd(@"
                SELECT r.BookingId, t.TrainNo, t.TrainName, tc.Class, r.SeatsBooked, r.DateOfTravel, r.TotalCost, r.IsDeleted
                FROM Reservations r
                JOIN TrainClasses tc ON r.TrainClassId = tc.TrainClassId
                JOIN Trains t ON tc.TrainId = t.TrainId
                WHERE r.CustId = @u
                ORDER BY r.DateOfTravel DESC");
            cmd.Parameters.AddWithValue("@u", uid);

            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                //if (!rd.HasRows)
                //{
                //    Console.WriteLine("No bookings found.");
                //    return;
                //}


                if (!rd.HasRows) { Ui.Warn("No bookings found."); return; }
                Ui.TableHeader("Id", "TrainNo", "TrainName", "Class", "Qty", "Date", "Total", "Cancelled");

                //Console.WriteLine("Id  TrainNo  TrainName           Class   Qty   Date       Total  Cancelled");
                while (rd.Read())
                {
                    Console.WriteLine(string.Format("{0,-3} {1,-8} {2,-18} {3,-7} {4,-4} {5:yyyy-MM-dd} {6,8} {7,-9}",
                        rd.GetInt32(0),         // Id
                        rd.GetString(1),        // TrainNo
                        rd.GetString(2),        // TrainName
                        rd.GetString(3),        // Class
                        rd.GetInt32(4),         // Qty
                        rd.GetDateTime(5),      // Date
                        rd.GetDecimal(6),       // Total
                        rd.GetBoolean(7) ? "Yes" : "No")); // Cancelled
                }

            }
        }

        public void Book(int uid, int trainId, string cls, int qty, DateTime dt)
        {//
            //if (dt.Date < DateTime.Today)
            //{
            //    Console.WriteLine("Travel date cannot be in the past. Please choose today or a future date.");
            //    return;
            //}

            if (dt.Date < DateTime.Today) { Ui.Warn("Travel date cannot be in the past."); return; }
            //
            SqlTransaction tx = Db.I.Conn.BeginTransaction();
            try
            {
                SqlCommand get = new SqlCommand(@"
                    SELECT TrainClassId, TotalSeats, CostPerSeat
                    FROM TrainClasses WITH (UPDLOCK, ROWLOCK)
                    WHERE TrainId=@t AND Class=@c", Db.I.Conn, tx);
                get.Parameters.AddWithValue("@t", trainId);
                get.Parameters.AddWithValue("@c", cls);

                int classId, avl;
                decimal price;
                using (SqlDataReader rd = get.ExecuteReader())
                {
                    if (!rd.Read())
                    {
                        Ui.Error("Invalid train/class.");
                        rd.Close();
                        tx.Rollback();
                        return;
                    }
                    classId = rd.GetInt32(0);
                    avl = rd.GetInt32(1);
                    price = rd.GetDecimal(2);
                }

                if (avl < qty)
                {
                    Console.WriteLine("Not enough seats.");
                    tx.Rollback();
                    return;
                }

                SqlCommand upd = new SqlCommand(@"
                    UPDATE TrainClasses SET TotalSeats = TotalSeats - @q
                    WHERE TrainClassId=@id", Db.I.Conn, tx);
                upd.Parameters.AddWithValue("@q", qty);
                upd.Parameters.AddWithValue("@id", classId);
                upd.ExecuteNonQuery();

                decimal total = qty * price;
                SqlCommand ins = new SqlCommand(@"
                    INSERT INTO Reservations(CustId, TrainClassId, DateOfTravel, SeatsBooked, TotalCost)
                    VALUES(@u, @tcid, @d, @q, @tot); SELECT SCOPE_IDENTITY();", Db.I.Conn, tx);
                ins.Parameters.AddWithValue("@u", uid);
                ins.Parameters.AddWithValue("@tcid", classId);
                ins.Parameters.AddWithValue("@d", dt);
                ins.Parameters.AddWithValue("@q", qty);
                ins.Parameters.AddWithValue("@tot", total);
                int bookingId = Convert.ToInt32(ins.ExecuteScalar());

                tx.Commit();
                Console.WriteLine($"Booked! BookingId={bookingId}, Amount={total}");
            }
            catch (Exception ex)
            {
                tx.Rollback();
                Console.WriteLine("Failed: " + ex.Message);
            }
        }

        public void Cancel(int bookingId)
        {
            SqlTransaction tx = Db.I.Conn.BeginTransaction();
            try
            {
                SqlCommand get = new SqlCommand(@"
                    SELECT TrainClassId, SeatsBooked, TotalCost, IsDeleted
                    FROM Reservations WITH (UPDLOCK)
                    WHERE BookingId=@b", Db.I.Conn, tx);
                get.Parameters.AddWithValue("@b", bookingId);

                int classId, qty;
                decimal total;
                using (SqlDataReader rd = get.ExecuteReader())
                {
                    if (!rd.Read())
                    {
                        Console.WriteLine("No such booking.");
                        rd.Close();
                        tx.Rollback();
                        return;
                    }
                    if (rd.GetBoolean(3))
                    {
                        Console.WriteLine("Already cancelled.");
                        rd.Close();
                        tx.Rollback();
                        return;
                    }
                    classId = rd.GetInt32(0);
                    qty = rd.GetInt32(1);
                    total = rd.GetDecimal(2);
                }

                SqlCommand updB = new SqlCommand("UPDATE Reservations SET IsDeleted=1 WHERE BookingId=@b", Db.I.Conn, tx);
                updB.Parameters.AddWithValue("@b", bookingId);
                updB.ExecuteNonQuery();

                SqlCommand addBack = new SqlCommand(@"
                    UPDATE TrainClasses SET TotalSeats = TotalSeats + @q
                    WHERE TrainClassId=@id", Db.I.Conn, tx);
                addBack.Parameters.AddWithValue("@q", qty);
                addBack.Parameters.AddWithValue("@id", classId);
                addBack.ExecuteNonQuery();

                decimal refund = Math.Round(total * 0.5m, 2);
                SqlCommand ins = new SqlCommand(@"
                    INSERT INTO Cancellations(BookingId, TicketCancelled, AmountRefunded)
                    VALUES(@b, @q, @r)", Db.I.Conn, tx);
                ins.Parameters.AddWithValue("@b", bookingId);
                ins.Parameters.AddWithValue("@q", qty);
                ins.Parameters.AddWithValue("@r", refund);
                ins.ExecuteNonQuery();

                tx.Commit();
                Console.WriteLine($"Cancelled. Refund = {refund}");
            }
            catch (Exception ex)
            {
                tx.Rollback();
                Console.WriteLine("Failed: " + ex.Message);
            }
        }
    }
}
