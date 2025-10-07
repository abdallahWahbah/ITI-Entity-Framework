using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Lab.Models
{
    internal class PriceOffer
    {
        public int PriceOfferId { get; set; }
        public decimal NewPrice { get; set; }
        public string PromotionalText { get; set; }

        // Navigation property
        //[ForeignKey("Book")] // no need for this line // if you name your FK as BookId, EF will automatically recognize it as the foreign key for the Book navigation property.
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
