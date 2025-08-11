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
                Console.WriteLine($"\n-- Admin: {uname} --");
                Console.WriteLine("1) Add Train");
                Console.WriteLine("2) Delete Train");
                Console.WriteLine("3) Update Train");
                Console.WriteLine("4) View All Trains");
                Console.WriteLine("5) View Train Classes");
                Console.WriteLine("6) Add Train Class");
                Console.WriteLine("7) View All Bookings");
                Console.WriteLine("8) View All Cancellations");
                Console.WriteLine("0) Logout");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Train No: ");
                    string no = Console.ReadLine();
                    Console.Write("Train Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Source: ");
                    string src = Console.ReadLine();
                    Console.Write("Destination: ");
                    string dst = Console.ReadLine();
                    admin.AddTrain(no, name, src, dst);
                }
                else if (choice == "2")
                {
                    int id = ReadInt("TrainId to delete: ");
                    admin.DeleteTrain(id);
                }
                else if (choice == "3")
                {
                    int id;
                    while (true)
                    {
                        Console.Write("Enter TrainId: ");
                        if (int.TryParse(Console.ReadLine(), out id))
                            break;
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                    }

                    admin.UpdateTrain(id);
                }
                else if (choice == "4")
                {
                    admin.ViewAllTrains();
                }
                else if (choice == "5")
                {
                    admin.ViewTrainClasses();
                }
                else if (choice == "6")
                {
                    int trainId = ReadInt("TrainId: ");
                    Console.Write("Class (e.g., Sleeper, 3AC): ");
                    string cls = Console.ReadLine();
                    int seats = ReadInt("Total Seats: ");
                    decimal price = ReadDecimal("Price per seat: ");
                    admin.AddTrainClass(trainId, cls, seats, price);
                }
                else if (choice == "7")
                {
                    admin.ViewAllBookings();
                }
                else if (choice == "8")
                {
                    admin.ViewAllCancellations();
                }
                else if (choice == "0")
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

        private static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal v)) return v;
                Console.WriteLine("Enter a valid decimal.");
            }
        }
    }
}
