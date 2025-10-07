using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Lab.Models
{
    internal class BookAuthor
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int Order { get; set; }


        // foreign keys
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
    }
}
