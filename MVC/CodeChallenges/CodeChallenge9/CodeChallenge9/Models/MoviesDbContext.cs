using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CodeChallenge9.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("DefaultConnection") { }

        public DbSet<Movie> Movies { get; set; }
    }

}




