using System;
using System.Data.SqlClient;

namespace MiniProject_RRS
{
    public class AdminService
    {
        private readonly TrainRepo _repo = new TrainRepo();

        public void AddTrain(string no, string name, string source, string destination)
        {
            _repo.AddTrain(no, name, source, destination);
        }

        public void DeleteTrain(int trainId)
        {
            SqlTransaction tx = Db.I.Conn.BeginTransaction();
            try
            {
                SqlCommand delTrain = new SqlCommand(
                    "UPDATE Trains SET IsDeleted = 1 WHERE TrainId = @id", Db.I.Conn, tx);
                delTrain.Parameters.AddWithValue("@id", trainId);
                delTrain.ExecuteNonQuery();

                SqlCommand delClasses = new SqlCommand(
                    "UPDATE TrainClasses SET IsDeleted = 1 WHERE TrainId = @id", Db.I.Conn, tx);
                delClasses.Parameters.AddWithValue("@id", trainId);
                delClasses.ExecuteNonQuery();

                tx.Commit();
                Console.WriteLine("Train and its classes marked as deleted.");
            }
            catch (Exception ex)
            {
                tx.Rollback();
                Console.WriteLine("Failed to delete train: " + ex.Message);
            }
        }


        public void UpdateTrain(int trainId)
        {
            Console.WriteLine("Choose what to update:");
            Console.WriteLine("1) Train No");
            Console.WriteLine("2) Train Name");
            Console.WriteLine("3) Source");
            Console.WriteLine("4) Destination");
            Console.WriteLine("5) Activation Status");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            SqlTransaction tx = Db.I.Conn.BeginTransaction();
            try
            {
                if (choice == "1")
                {
                    Console.Write("New Train No: ");
                    string trainNo = Console.ReadLine();
                    SqlCommand cmd = new SqlCommand("UPDATE Trains SET TrainNo=@no WHERE TrainId=@id", Db.I.Conn, tx);
                    cmd.Parameters.AddWithValue("@no", trainNo);
                    cmd.Parameters.AddWithValue("@id", trainId);
                    cmd.ExecuteNonQuery();
                }
                else if (choice == "2")
                {
                    Console.Write("New Train Name: ");
                    string name = Console.ReadLine();
                    SqlCommand cmd = new SqlCommand("UPDATE Trains SET TrainName=@name WHERE TrainId=@id", Db.I.Conn, tx);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@id", trainId);
                    cmd.ExecuteNonQuery();
                }
                else if (choice == "3")
                {
                    Console.Write("New Source: ");
                    string source = Console.ReadLine();
                    SqlCommand cmd = new SqlCommand("UPDATE Trains SET Source=@src WHERE TrainId=@id", Db.I.Conn, tx);
                    cmd.Parameters.AddWithValue("@src", source);
                    cmd.Parameters.AddWithValue("@id", trainId);
                    cmd.ExecuteNonQuery();
                }
                else if (choice == "4")
                {
                    Console.Write("New Destination: ");
                    string destination = Console.ReadLine();
                    SqlCommand cmd = new SqlCommand("UPDATE Trains SET Destination=@dst WHERE TrainId=@id", Db.I.Conn, tx);
                    cmd.Parameters.AddWithValue("@dst", destination);
                    cmd.Parameters.AddWithValue("@id", trainId);
                    cmd.ExecuteNonQuery();
                }
                else if (choice == "5")
                {
                    Console.Write("Activate train? (yes/no): ");
                    string input = Console.ReadLine().Trim().ToLower();
                    bool activate = input == "yes";

                    SqlCommand cmdTrain = new SqlCommand("UPDATE Trains SET IsDeleted=@flag WHERE TrainId=@id", Db.I.Conn, tx);
                    cmdTrain.Parameters.AddWithValue("@flag", activate ? 0 : 1);
                    cmdTrain.Parameters.AddWithValue("@id", trainId);
                    cmdTrain.ExecuteNonQuery();

                    SqlCommand cmdClasses = new SqlCommand("UPDATE TrainClasses SET IsDeleted=@flag WHERE TrainId=@id", Db.I.Conn, tx);
                    cmdClasses.Parameters.AddWithValue("@flag", activate ? 0 : 1);
                    cmdClasses.Parameters.AddWithValue("@id", trainId);
                    cmdClasses.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    tx.Rollback();
                    return;
                }

                tx.Commit();
                Console.WriteLine("Train updated successfully.");
            }
            catch (Exception ex)
            {
                tx.Rollback();
                Console.WriteLine("Update failed: " + ex.Message);
            }
        }


        public void ViewAllTrains()
        {
            SqlCommand cmd = Db.I.Cmd("SELECT TrainId, TrainNo, TrainName, Source, Destination, IsDeleted FROM Trains ORDER BY TrainNo");
            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                Console.WriteLine("Id No Name Source Destination Deleted");
                while (rd.Read())
                {
                    Console.WriteLine(string.Format("{0,-3} {1,-6} {2,-16} {3,-10} {4,-10} {5}",
                        rd.GetInt32(0),
                        rd.GetString(1),
                        rd.GetString(2),
                        rd.GetString(3),
                        rd.GetString(4),
                        rd.GetBoolean(5) ? "Yes" : "No"));
                }
            }
        }

        public void ViewTrainClasses()
        {
            SqlCommand cmd = Db.I.Cmd(@"
        SELECT tc.TrainClassId, t.TrainNo, tc.Class, tc.TotalSeats, tc.CostPerSeat, tc.IsDeleted
        FROM TrainClasses tc
        JOIN Trains t ON tc.TrainId = t.TrainId
        ORDER BY t.TrainNo, tc.Class");

            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                Console.WriteLine("ClassId TrainNo Class Seats Price Deleted");
                while (rd.Read())
                {
                    Console.WriteLine(string.Format("{0,-7} {1,-6} {2,-5} {3,3} {4,6} {5}",
                        rd.GetInt32(0),
                        rd.GetString(1),
                        rd.GetString(2),
                        rd.GetInt32(3),
                        rd.GetDecimal(4),
                        rd.GetBoolean(5) ? "Yes" : "No"));
                }
            }
        }

        public void AddTrainClass(int trainId, string classCode, int totalSeats, decimal price)
        {
            SqlCommand check = Db.I.Cmd("SELECT COUNT(*) FROM Trains WHERE TrainId = @id");
            check.Parameters.AddWithValue("@id", trainId);
            int exists = Convert.ToInt32(check.ExecuteScalar());

            if (exists == 0)
            {
                Console.WriteLine("Error: TrainId does not exist. Please add the train first.");
                return;
            }

            SqlCommand cmd = Db.I.Cmd(@"
        INSERT INTO TrainClasses(TrainId, Class, TotalSeats, CostPerSeat)
        VALUES(@t, @c, @tot, @p)");
            cmd.Parameters.AddWithValue("@t", trainId);
            cmd.Parameters.AddWithValue("@c", classCode);
            cmd.Parameters.AddWithValue("@tot", totalSeats);
            cmd.Parameters.AddWithValue("@p", price);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Train class added.");
        }

        public void ViewAllBookings()
        {
            SqlCommand cmd = Db.I.Cmd(@"
                SELECT r.BookingId, c.CustName, t.TrainName, tc.Class, r.SeatsBooked, r.DateOfTravel, r.TotalCost
                FROM Reservations r
                JOIN Customers c ON r.CustId = c.CustId
                JOIN TrainClasses tc ON r.TrainClassId = tc.TrainClassId
                JOIN Trains t ON tc.TrainId = t.TrainId
                ORDER BY r.DateOfBooking DESC");

            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                Console.WriteLine("Id Name Train Class Qty Date Cost");
                while (rd.Read())
                {
                    Console.WriteLine(string.Format("{0,-3} {1,-10} {2,-16} {3,-5} {4,3} {5:yyyy-MM-dd} {6,6}",
                        rd.GetInt32(0),
                        rd.GetString(1),
                        rd.GetString(2),
                        rd.GetString(3),
                        rd.GetInt32(4),
                        rd.GetDateTime(5),
                        rd.GetDecimal(6)));
                }
            }
        }

        public void ViewAllCancellations()
        {
            SqlCommand cmd = Db.I.Cmd(@"
                SELECT CancelId, BookingId, TicketCancelled, AmountRefunded, DateOfCancellation
                FROM Cancellations
                ORDER BY DateOfCancellation DESC");

            using (SqlDataReader rd = cmd.ExecuteReader())
            {
                Console.WriteLine("CancelId BookingId Qty Refund Date");
                while (rd.Read())
                {
                    Console.WriteLine(string.Format("{0,-5} {1,-5} {2,-3} {3,6} {4:yyyy-MM-dd}",
                        rd.GetInt32(0),
                        rd.GetInt32(1),
                        rd.GetInt32(2),
                        rd.GetDecimal(3),
                        rd.GetDateTime(4)));
                }
            }
        }
    }
}
