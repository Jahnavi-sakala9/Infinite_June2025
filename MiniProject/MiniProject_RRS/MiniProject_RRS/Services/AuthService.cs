using System;

namespace MiniProject_RRS
{
    public class AuthService
    {
        private readonly UserRepo _repo = new UserRepo();

        
        public User Login(string email, string password)
        {
            return _repo.Get(email, password);
        }
        public int Register(string name, string phone, string email, string password)
        {
            return _repo.Register(name, phone, email, password);
        }
    }
}
