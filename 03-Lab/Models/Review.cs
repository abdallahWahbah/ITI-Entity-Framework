using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Lab.Models
{
    internal class Review
    {
        public int ReviewId { get; set; }
        public string Votername { get; set; }
        public int NumStars { get; set; }
        public string Comment { get; set; }

        // Navigation property

        //[ForeignKey("Book")] // no need for this line // if you name your FK as BookId, EF will automatically recognize it as the foreign key for the Book navigation property.
        public int BookId { get; set; } 
        public Book Book { get; set; }

    }
}
