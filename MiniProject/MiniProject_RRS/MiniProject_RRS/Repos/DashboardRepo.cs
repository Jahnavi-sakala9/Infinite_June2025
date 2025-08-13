using System;
using System.Data.SqlClient;

namespace MiniProject_RRS
{
    public class DashboardRepo
    {
        private static T Scalar<T>(string sql, Action<SqlCommand> set = null, T def = default(T))
        {
            var cmd = Db.I.Cmd(sql);
            if (set != null) set(cmd);
            object v = cmd.ExecuteScalar();
            if (v == null || v == DBNull.Value) return def;
            return (T)Convert.ChangeType(v, typeof(T));
        }

        private static void KPI(string label, string value)
        {
            Ui.Info(label.PadRight(24) + ": " + value);
        }

        public void AdminDashboard()
        {
            Ui.Banner("Admin Dashboard");

            int totalCustomers = Scalar<int>("SELECT COUNT(*) FROM Customers WHERE IsDeleted=0", null, 0);
            int totalTrains = Scalar<int>("SELECT COUNT(*) FROM Trains", null, 0);
            int totalClasses = Scalar<int>("SELECT COUNT(*) FROM TrainClasses", null, 0);
            int totalBookings = Scalar<int>("SELECT COUNT(*) FROM Reservations WHERE IsDeleted=0", null, 0);
            int totalCancelled = Scalar<int>("SELECT COUNT(*) FROM Reservations WHERE IsDeleted=1", null, 0);
            decimal totalRevenue = Scalar<decimal>("SELECT COALESCE(SUM(TotalCost),0) FROM Reservations WHERE IsDeleted=0", null, 0m);
            decimal totalRefunds = Scalar<decimal>("SELECT COALESCE(SUM(AmountRefunded),0) FROM Cancellations", null, 0m);

            Ui.TableHeader("OVERALL TOTALS");
            KPI("Customers", totalCustomers.ToString());
            KPI("Trains", totalTrains.ToString());
            KPI("Train Classes", totalClasses.ToString());
            KPI("Bookings (active)", totalBookings.ToString());
            KPI("Bookings (cancelled)", totalCancelled.ToString());
            KPI("Revenue (all time)", totalRevenue.ToString("0.00"));
            KPI("Refunds (all time)", totalRefunds.ToString("0.00"));
            Ui.Divider();

            DateTime today = DateTime.Today;

            int todayBookings = Scalar<int>(
               "SELECT COUNT(*) FROM Reservations WHERE CAST(DateOfBooking AS date)=@d AND IsDeleted=0",
                c => c.Parameters.AddWithValue("@d", today), 0);
            int todayCancels = Scalar<int>(
                "SELECT COUNT(*) FROM Cancellations WHERE CAST(DateOfCancellation AS date)=@d",
                c => c.Parameters.AddWithValue("@d", today), 0);
            decimal todayRevenue = Scalar<decimal>(
                "SELECT COALESCE(SUM(TotalCost),0) FROM Reservations WHERE CAST(DateOfBooking AS date)=@d AND IsDeleted=0",
                c => c.Parameters.AddWithValue("@d", today), 0m);
            decimal todayRefunds = Scalar<decimal>(
                "SELECT COALESCE(SUM(AmountRefunded),0) FROM Cancellations WHERE CAST(DateOfCancellation AS date)=@d",
                c => c.Parameters.AddWithValue("@d", today), 0m);

            Ui.TableHeader("TODAY");
            KPI("New bookings today", todayBookings.ToString());
            KPI("Cancellations today", todayCancels.ToString());
            KPI("Revenue today", todayRevenue.ToString("0.00"));
            KPI("Refunds today", todayRefunds.ToString("0.00"));
            Ui.Divider();

            int upcomingTrips = Scalar<int>(
                "SELECT COUNT(*) FROM Reservations WHERE IsDeleted=0 AND DateOfTravel >= @d",
                c => c.Parameters.AddWithValue("@d", today), 0);

            Ui.TableHeader("UPCOMING");
            KPI("Trips remaining (system)", upcomingTrips.ToString());
            Ui.Divider();

            Ui.TableHeader("TOP TRAINS (by active bookings)");
            using (var cmd = Db.I.Cmd(@"
                SELECT TOP 5 t.TrainNo, t.TrainName, COUNT(*) AS BookCount
                FROM Reservations r
                JOIN TrainClasses tc ON r.TrainClassId = tc.TrainClassId
                JOIN Trains t ON tc.TrainId = t.TrainId
                WHERE r.IsDeleted=0
                GROUP BY t.TrainNo, t.TrainName
                ORDER BY BookCount DESC, t.TrainNo ASC;"))
            using (var rd = cmd.ExecuteReader())
            {
                bool any = false;
                while (rd.Read())
                {
                    any = true;
                    Ui.Success(rd.GetString(0) + "  " + rd.GetString(1) + "  —  " + rd.GetInt32(2) + " bookings");
                }
                if (!any) Ui.Warn("No booking data yet.");
            }
        }

        public void UserDashboard(int userId)
        {
            Ui.Banner("My Dashboard");

            DateTime today = DateTime.Today;

            int myActive = Scalar<int>(
                "SELECT COUNT(*) FROM Reservations WHERE CustId=@u AND IsDeleted=0",
                c => c.Parameters.AddWithValue("@u", userId), 0);
            int myCancelled = Scalar<int>(
                "SELECT COUNT(*) FROM Reservations WHERE CustId=@u AND IsDeleted=1",
                c => c.Parameters.AddWithValue("@u", userId), 0);
            int myUpcoming = Scalar<int>(
                "SELECT COUNT(*) FROM Reservations WHERE CustId=@u AND IsDeleted=0 AND DateOfTravel >= @d",
                c => { c.Parameters.AddWithValue("@u", userId); c.Parameters.AddWithValue("@d", today); }, 0);
            decimal mySpend = Scalar<decimal>(
                "SELECT COALESCE(SUM(TotalCost),0) FROM Reservations WHERE CustId=@u AND IsDeleted=0",
                c => c.Parameters.AddWithValue("@u", userId), 0m);
            DateTime nextTrip = Scalar<DateTime>(
                "SELECT TOP 1 DateOfTravel FROM Reservations WHERE CustId=@u AND IsDeleted=0 AND DateOfTravel >= @d ORDER BY DateOfTravel",
                c => { c.Parameters.AddWithValue("@u", userId); c.Parameters.AddWithValue("@d", today); }, DateTime.MinValue);

            Ui.TableHeader("MY TOTALS");
            KPI("Active bookings", myActive.ToString());
            KPI("Cancelled bookings", myCancelled.ToString());
            KPI("Upcoming trips", myUpcoming.ToString());
            KPI("Total spent", mySpend.ToString("0.00"));
            KPI("Next trip", nextTrip == DateTime.MinValue ? "-" : nextTrip.ToString("yyyy-MM-dd"));
            Ui.Divider();

            Ui.TableHeader("RECENT BOOKINGS");
            using (var cmd = Db.I.Cmd(@"
                SELECT TOP 5 r.BookingId, t.TrainNo, t.TrainName, tc.Class, r.SeatsBooked, r.DateOfTravel, r.TotalCost
                FROM Reservations r
                JOIN TrainClasses tc ON r.TrainClassId = tc.TrainClassId
                JOIN Trains t ON tc.TrainId = t.TrainId
                WHERE r.CustId = @u
                ORDER BY r.BookingId DESC;"))
            {
                cmd.Parameters.AddWithValue("@u", userId);
                using (var rd = cmd.ExecuteReader())
                {
                    bool any = false;
                    while (rd.Read())
                    {
                        any = true;
                        Console.WriteLine(
                            "#" + rd.GetInt32(0).ToString().PadLeft(4) + "  " +
                            rd.GetString(1).PadRight(6) + " " +
                            rd.GetString(2).PadRight(16) + "  " +
                            rd.GetString(3).PadRight(6) + "  x" +
                            rd.GetInt32(4).ToString().PadLeft(2) + "  " +
                            rd.GetDateTime(5).ToString("yyyy-MM-dd") + "  " +
                            rd.GetDecimal(6).ToString("0.00"));
                    }
                    if (!any) Ui.Warn("No bookings yet.");
                }
            }
        }
    }
}


