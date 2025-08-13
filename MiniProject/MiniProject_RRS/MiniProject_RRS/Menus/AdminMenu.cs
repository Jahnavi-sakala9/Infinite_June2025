using System;

namespace MiniProject_RRS
{
    public static class AdminMenu
    {
        private static readonly AdminService admin = new AdminService();

        public static void Run(int uid, string uname)
        {
            while (true)
            {
                Ui.Banner("Admin: " + uname);
                Console.WriteLine("1) Add Train");
                Console.WriteLine("2) Delete Train");
                Console.WriteLine("3) Update Train");
                Console.WriteLine("4) View All Trains");
                Console.WriteLine("5) View Train Classes");
                Console.WriteLine("6) Add/Update Train Class");
                Console.WriteLine("7) View All Bookings");
                Console.WriteLine("8) View All Cancellations");
                Console.WriteLine("9) Dashboard");
                Console.WriteLine("0) Logout");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Train No: "); string no = Console.ReadLine();
                    Console.Write("Train Name: "); string name = Console.ReadLine();
                    Console.Write("Source: "); string src = Console.ReadLine();
                    Console.Write("Destination: "); string dst = Console.ReadLine();
                    bool ok = new TrainRepo().AddTrain(no, name, src, dst);
                    if (ok) Ui.Success("Train added.");
                    else Ui.Error("Failed to add train (duplicate TrainNo?).");
                    Ui.Pause();
                }
                else if (choice == "2")
                {
                    int id = ReadInt("TrainId to delete: ");
                    bool ok = admin.DeleteTrain(id);
                    if (ok) Ui.Success("Train deleted.");
                    else Ui.Warn("No train deleted (invalid id?).");
                    Ui.Pause();
                }
                else if (choice == "3")
                {
                    int id = ReadInt("Enter TrainId: ");
                    admin.UpdateTrain(id);               // your implementation
                    Ui.Success("Train updated (if data changed).");
                    Ui.Pause();
                }
                else if (choice == "4")
                {
                    Ui.Banner("All Trains");
                    admin.ViewAllTrains();
                    Ui.Pause();
                }
                else if (choice == "5")
                {
                    Ui.Banner("Train Classes");
                    admin.ViewTrainClasses();
                    Ui.Pause();
                }
                else if (choice == "6")
                {
                    int trainId = ReadInt("TrainId: ");
                    Console.Write("Class (e.g., Sleeper, 3AC): "); string cls = Console.ReadLine();
                    int seats = ReadInt("Total Seats: ");
                    decimal price = ReadDecimal("Price per seat: ");
                    admin.AddTrainClass(trainId, cls, seats, price);
                    Ui.Success("Class upserted for train.");
                    Ui.Pause();
                }
                else if (choice == "7")
                {
                    Ui.Banner("All Bookings");
                    admin.ViewAllBookings();
                    Ui.Pause();
                }
                else if (choice == "8")
                {
                    Ui.Banner("All Cancellations");
                    admin.ViewAllCancellations();
                    Ui.Pause();
                }
                else if (choice == "9")
                {
                    new DashboardRepo().AdminDashboard();
                    Ui.Pause();
                }
                else if (choice == "0")
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
                Ui.Warn("Invalid input. Please enter a valid integer.");
            }
        }

        private static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                decimal v;
                if (decimal.TryParse(Console.ReadLine(), out v)) return v;
                Ui.Warn("Invalid input. Please enter a valid decimal.");
            }
        }
    }
}
