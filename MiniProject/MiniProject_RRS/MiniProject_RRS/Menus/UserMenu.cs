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
                Console.WriteLine($"\n-- User: {uname} --");
                Console.WriteLine("1) Search trains 2) Book 3) My bookings 4) Cancel 0) Logout");
                Console.Write("Choice: ");
                string c = Console.ReadLine();

                if (c == "1")
                {
                    Console.Write("Source: ");
                    string s = Console.ReadLine();
                    Console.Write("Destination: ");
                    string d = Console.ReadLine();
                    svc.Search(s, d);
                }
                else if (c == "2")
                {
                    int t = ReadInt("TrainId: ");
                    Console.Write("Class (Sleeper/3AC/2AC): ");
                    string cls = Console.ReadLine();
                    int q = ReadInt("Quantity: ");
                    DateTime dt = ReadDate("Travel Date (yyyy-mm-dd): ");
                    svc.Book(uid, t, cls, q, dt);
                }
                else if (c == "3")
                {
                    svc.MyBookings(uid);
                }
                else if (c == "4")
                {
                    int bid = ReadInt("BookingId to cancel: ");
                    svc.Cancel(bid);
                }
                else if (c == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int v)) return v;
                Console.WriteLine("Enter a valid integer.");
            }
        }

        private static DateTime ReadDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (DateTime.TryParse(Console.ReadLine(), out DateTime v)) return v;
                Console.WriteLine("Enter a valid date (yyyy-mm-dd).");
            }
        }
    }
}
