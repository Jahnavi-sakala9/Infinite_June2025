using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Assignment1.Models
{
    public class Contact
    {
        public long Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; } = "";

        [Required, StringLength(50)]
        public string LastName { get; set; } = "";

        [Required, EmailAddress, StringLength(100)]
        public string Email { get; set; } = "";
    }

    public class ContactContext : DbContext
    {
        public ContactContext() : base("name=DefaultConnection") { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
