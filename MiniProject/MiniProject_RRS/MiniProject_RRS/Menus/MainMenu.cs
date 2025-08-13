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

            var user = repo.Get(email, password);
            if (user == null) Ui.Error("Invalid credentials.");
            else Ui.Success($"Welcome, {user.Username}!");

            return user;
        }

        public static void Register()
        {
            Console.Write("Name: "); string name = Console.ReadLine();
            Console.Write("Phone: "); string phone = Console.ReadLine();
            Console.Write("Email: "); string email = Console.ReadLine();
            Console.Write("Password: "); string password = Console.ReadLine();

            int result = repo.Register(name, phone, email, password);
            if (result > 0) Ui.Success("Registration successful!");
            else Ui.Error("Registration failed.");
            Ui.Pause();
        }

    }
}

    
