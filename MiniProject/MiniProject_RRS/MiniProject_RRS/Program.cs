using System;

namespace MiniProject_RRS
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = "Data Source=ICS-LT-1YX9J84\\SQLEXPRESS;Initial Catalog=RRSdatabase;" +
                                "user id=sa;password=Sakalajahnavi@123;";
            Db.Init(connection);

            while (true)
            {
                Console.WriteLine("\n=== Railway Reservation System ===");
                Console.WriteLine("1) Login");
                Console.WriteLine("2) Register");
                Console.WriteLine("0) Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    var user = MainMenu.Login();
                    if (user == null)
                    {
                        Console.WriteLine("Invalid login.");
                        continue;
                    }

                    if (user.Role == "ADMIN")
                        AdminMenu.Run(user.UserId, user.Username);
                    else
                        UserMenus.Run(user.UserId, user.Username);
                }
                else if (choice == "2")
                {
                    MainMenu.Register();
                }
                else if (choice == "0")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }
    }
}

