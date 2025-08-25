using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace CodeChallenge9.Models
{
    public class Movie
    {
        [Key]
        public int Mid { get; set; }
        [Required]
        public string MovieName { get; set; }
        public string DirectorName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfRelease { get; set; }
    }


}







