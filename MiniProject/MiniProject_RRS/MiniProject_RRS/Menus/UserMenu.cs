using System;

namespace MiniProject_RRS
{
    public static class UserMenus
    {
        private static readonly BookingService svc = new BookingService();

        public static void Run(int uid, string uname)
        {
            while (true)
            {
                Ui.Banner("User: " + uname);
                Console.WriteLine("1) Search trains  2) Book  3) My bookings  4) Cancel  5) My dashboard  0) Logout");
                Console.Write("Choice: ");
                string c = Console.ReadLine();

                if (c == "1")
                {
                    Console.Write("Source: "); string s = Console.ReadLine();
                    Console.Write("Destination: "); string d = Console.ReadLine();
                    Ui.Banner("Trains " + s + " → " + d);
                    svc.Search(s, d);
                    Ui.Pause();
                }
                else if (c == "2")
                {
                    int t = ReadInt("TrainId: ");
                    Console.Write("Class (Sleeper/3AC/2AC): "); string cls = Console.ReadLine();
                    int q = ReadInt("Quantity: ");
                    DateTime dt = ReadDateTodayOrFuture("Travel Date (yyyy-MM-dd): ");
                    svc.Book(uid, t, cls, q, dt);
                    Ui.Pause();
                }
                else if (c == "3")
                {
                    Ui.Banner("My Bookings");
                    svc.MyBookings(uid);
                    Ui.Pause();
                }
                else if (c == "4")
                {
                    int bid = ReadInt("BookingId to cancel: ");
                    if (Ui.Confirm())
                        svc.Cancel(bid);
                    else
                        Ui.Info("Cancelled by user. No action taken.");
                    Ui.Pause();
                }
                else if (c == "5")
                {
                    new DashboardRepo().UserDashboard(uid);
                    Ui.Pause();
                }
                else if (c == "0")
                {
                    break;
                }
                else
                {
                    Ui.Warn("Invalid choice.");
                }
            }
        }

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                int v;
                if (int.TryParse(Console.ReadLine(), out v)) return v;
                Ui.Warn("Enter a valid integer.");
            }
        }

        private static DateTime ReadDateTodayOrFuture(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                DateTime v;
                if (!DateTime.TryParse(Console.ReadLine(), out v))
                {
                    Ui.Warn("Enter a valid date (yyyy-MM-dd).");
                    continue;
                }
                if (v.Date < DateTime.Today)
                {
                    Ui.Warn("Date must be today or a future date.");
                    continue;
                }
                return v.Date;
            }
        }
    }
}
