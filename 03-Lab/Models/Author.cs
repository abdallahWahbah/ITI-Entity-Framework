using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Lab.Models
{
    internal class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public virtual List<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
