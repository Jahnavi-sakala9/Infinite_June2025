using System;
using System.Data.SqlClient;

namespace MiniProject_RRS
{
    public class AdminService
    {
        private readonly TrainRepo trains = new TrainRepo();

        public bool DeleteTrain(int trainId)
        {
            // Soft delete the train and its classes so history/reservations remain intact
            using (var tx = Db.I.Conn.BeginTransaction())
            {
                try
                {
                    // mark classes deleted
                    var cmd1 = new SqlCommand(
                        "UPDATE TrainClasses SET IsDeleted = 1 WHERE TrainId = @id",
                        Db.I.Conn, tx);
                    cmd1.Parameters.AddWithValue("@id", trainId);
                    cmd1.ExecuteNonQuery();

                    // mark train deleted
                    var cmd2 = new SqlCommand(
                        "UPDATE Trains SET IsDeleted = 1 WHERE TrainId = @id",
                        Db.I.Conn, tx);
                    cmd2.Parameters.AddWithValue("@id", trainId);
                    int rows = cmd2.ExecuteNonQuery();

                    tx.Commit();
                    if (rows > 0) Ui.Success("Train marked as deleted.");
                    else Ui.Warn("No train found with that id.");
                    return rows > 0;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    Ui.Error("Failed to delete (soft): " + ex.Message);
                    return false;
                }
            }
        }


        public void UpdateTrain(int trainId)
        {
            // Example: prompt for new name (you can expand as needed)
            Console.Write("New Train Name (leave empty to skip): ");
            string nm = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nm))
            {
                var cmd = Db.I.Cmd("UPDATE Trains SET TrainName=@n WHERE TrainId=@id");
                cmd.Parameters.AddWithValue("@n", nm);
                cmd.Parameters.AddWithValue("@id", trainId);
                cmd.ExecuteNonQuery();
            }
        }

        public void ViewAllTrains()
        {
            using (var cmd = Db.I.Cmd("SELECT TrainId, TrainNo, TrainName, Source, Destination FROM Trains ORDER BY TrainNo"))
            using (var rd = cmd.ExecuteReader())
            {
                Ui.TableHeader($"{ "Id",-4} {"Train No.",-10}   {"Name",-18} {"From",-18} {"To",-10}");
                bool any = false;
                while (rd.Read())
                {
                    any = true;
                    Console.WriteLine(
                        string.Format("{0,-4}  {1,-10}  {2,-18}  {3,-18}  {4,-10}",
                        rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4)));
                }
                if (!any) Ui.Warn("No trains.");
            }
        }

        public void ViewTrainClasses()
        {
            using (var cmd = Db.I.Cmd(@"
                SELECT tc.TrainClassId, t.TrainNo, t.TrainName, tc.Class, tc.TotalSeats, tc.CostPerSeat
                FROM TrainClasses tc
                JOIN Trains t ON t.TrainId = tc.TrainId
                ORDER BY t.TrainNo, tc.Class"))
            using (var rd = cmd.ExecuteReader())
            {
                Ui.TableHeader($"{"ClassId",-7} {"Train No.",-10} {"Name",-18} {"Class",-6} {"Seats",-5} {"Price",-8}");
                bool any = false;
                while (rd.Read())
                {
                    any = true;
                    Console.WriteLine(
                        string.Format("{0,-7}  {1,-10}  {2,-18}  {3,-6}  {4,-5}  {5,-8}",
                        rd.GetInt32(0), rd.GetString(1), rd.GetString(2),
                        rd.GetString(3), rd.GetInt32(4), rd.GetDecimal(5)));
                }
                if (!any) Ui.Warn("No classes.");
            }
        }

        public void AddTrainClass(int trainId, string cls, int seats, decimal price)
        {
            trains.UpsertClass(trainId, cls, seats, price);
        }

        public void ViewAllBookings()
        {
            using (var cmd = Db.I.Cmd(@"
                SELECT r.BookingId, t.TrainNo, t.TrainName, tc.Class, r.SeatsBooked, r.DateOfTravel, r.TotalCost, r.IsDeleted
                FROM Reservations r
                JOIN TrainClasses tc ON r.TrainClassId = tc.TrainClassId
                JOIN Trains t ON tc.TrainId = t.TrainId
                ORDER BY r.BookingId DESC"))
            using (var rd = cmd.ExecuteReader())
            {
                Ui.TableHeader("Id", "No", "Name", "Class", "Qty", "Date", "Total", "Cancelled");
                bool any = false;
                while (rd.Read())
                {
                    any = true;
                    Console.WriteLine(string.Format("{0,-4} {1,-6} {2,-16} {3,-6} {4,3} {5:yyyy-MM-dd} {6,8} {7}",
                        rd.GetInt32(0), rd.GetString(1), rd.GetString(2), rd.GetString(3),
                        rd.GetInt32(4), rd.GetDateTime(5), rd.GetDecimal(6),
                        rd.GetBoolean(7) ? "Yes" : "No"));
                }
                if (!any) Ui.Warn("No bookings yet.");
            }
        }

        public void ViewAllCancellations()
        {
            using (var cmd = Db.I.Cmd(@"
                SELECT c.CancelId, c.BookingId, c.TicketCancelled, c.AmountRefunded, c.DateOfCancellation
                FROM Cancellations c
                ORDER BY c.CancelId DESC"))
            using (var rd = cmd.ExecuteReader())
            {
                Ui.TableHeader($"{"CancelId",-8} {"BookingId",-9} {"Qty",-3} {"Refund",-8} {"Date"}");
                bool any = false;
                while (rd.Read())
                {
                    any = true;
                    Console.WriteLine(
                        string.Format("{0,-8}  {1,-9}  {2,-3}  {3,-8}  {4:yyyy-MM-dd HH:mm}",
                        rd.GetInt32(0), rd.GetInt32(1), rd.GetInt32(2), rd.GetDecimal(3), rd.GetDateTime(4)));
                }
                if (!any) Ui.Warn("No cancellations yet.");
            }
        }
    }
}
