using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Lab.Models
{
    internal class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedOn { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        // Navigation properties
        public virtual List<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
        public virtual List<Tag> Tags { get; set; } = new List<Tag>(); // BookTage table will be auto-generated
        public PriceOffer PriceOffer { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
