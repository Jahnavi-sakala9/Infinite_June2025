using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MiniProject_RRS;

namespace ProjectTests
{
    public class UserRepoTests : TestBase
    {
        [Test]
        public void Register_Then_Login_Succeeds()
        {
            // arrange
            var repo = new UserRepo();
            string name = "Test User";
            string phone = "9999999999";
            string email = $"u{Guid.NewGuid():N}@mail.com";
            string password = "secret";

            // act
            int rows = repo.Register(name, phone, email, password);
            var user = repo.Get(email, password);

            // assert
            Assert.That(rows, Is.GreaterThan(0), "Register should insert a row.");
            Assert.That(user, Is.Not.Null, "Login should return a user.");
            Assert.That(user!.Username, Is.EqualTo(name));
            Assert.That(user.Role, Is.EqualTo("USER").Or.EqualTo("ADMIN")); // depends on your seed/default
        }

        [Test]
        public void Login_With_Wrong_Password_Returns_Null()
        {
            // arrange
            var repo = new UserRepo();
            string email = $"u{Guid.NewGuid():N}@mail.com";
            string password = "secret";

            // register first
            int rows = repo.Register("Bob", "8888888888", email, password);
            Assert.That(rows, Is.GreaterThan(0));

            // act
            var user = repo.Get(email, "wrong-password");

            // assert
            Assert.That(user, Is.Null, "Login with wrong password should return null.");
        }
    }
}
