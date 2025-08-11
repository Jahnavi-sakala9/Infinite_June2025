using System;

namespace MiniProject_RRS
{
    public static class MainMenu
    {

        private static readonly UserRepo repo = new UserRepo();

        public static User Login()
        {
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            return repo.Get(email, password);
        }

        public static void Register()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            int result = repo.Register(name, phone, email, password);
            Console.WriteLine(result > 0 ? "Registration successful!" : "Registration failed.");
        }
    }
}

    
