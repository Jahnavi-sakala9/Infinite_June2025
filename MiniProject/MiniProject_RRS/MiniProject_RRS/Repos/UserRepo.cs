using System;
using System.Data.SqlClient;

namespace MiniProject_RRS
{
    public class UserRepo
    {
        public User Get(string username, string password)
        {
            var cmd = Db.I.Cmd(@"
                SELECT CustId, CustName, Role
                FROM Customers
                WHERE MailId=@u AND Password=@p AND IsDeleted=0;");

            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);

            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.Read()) return null;

                var user = new User
                {
                    UserId = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Role = reader.GetString(2).ToUpper()
                };
                return user;
            }
        }

        public int Register(string name, string phone, string email, string password)
        {
            var cmd = Db.I.Cmd(@"
                INSERT INTO Customers (CustName, Phone, MailId, Password, Role, IsDeleted)
                VALUES (@n, @p, @m, @pw, 'User', 0);
                SELECT @@ROWCOUNT;");

            cmd.Parameters.AddWithValue("@n", name);

            if (string.IsNullOrEmpty(phone))
                cmd.Parameters.AddWithValue("@p", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@p", phone);

            cmd.Parameters.AddWithValue("@m", email);
            cmd.Parameters.AddWithValue("@pw", password);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}
