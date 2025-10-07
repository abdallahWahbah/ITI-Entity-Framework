using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Lab.Models
{
    internal class Tag
    {
        public int TagId { get; set; }

        // Navigation property
        public virtual List<Book> Books { get; set; } = new List<Book>();
    }
}
