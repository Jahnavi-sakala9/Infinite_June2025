using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using NUnit.Framework;
using MiniProject_RRS;

namespace RRS_Testing
{
    public class UserRepoTests : TestBase
    {
        [Test]
        public void Register_Then_Login_Succeeds()
        {
            var repo = new MiniProject_RRS.UserRepo();
            string name = "Test User";
            string phone = "9999999999";
            string email = "u" + Guid.NewGuid().ToString("N") + "@mail.com";
            string password = "secret";

            int rows = repo.Register(name, phone, email, password);
            var user = repo.Get(email, password);

            Assert.That(rows, Is.GreaterThan(0));
            Assert.That(user, Is.Not.Null);
            Assert.That(user.UserId, Is.GreaterThan(0));   // ✅ no user!
            Assert.That(user.Username, Is.EqualTo(name));
        }

        [Test]
        public void Login_With_Wrong_Password_Returns_Null()
        {
            var repo = new MiniProject_RRS.UserRepo();
            string email = "u" + Guid.NewGuid().ToString("N") + "@mail.com";
            repo.Register("Bob", "8888888888", email, "secret");

            var user = repo.Get(email, "wrong-password");

            Assert.That(user, Is.Null);
        }
    }
}
