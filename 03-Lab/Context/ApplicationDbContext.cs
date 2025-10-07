using _03_Lab.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Lab.Context
{
    internal class ApplicationDbContext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;database=DbTest;integrated security=true; trust server certificate=true"); 
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // composite fk for book-author relation
            modelBuilder.Entity<BookAuthor>(BA =>
            {
                BA.HasKey(e => new { e.AuthorId, e.BookId});
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
