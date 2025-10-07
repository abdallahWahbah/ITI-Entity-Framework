using _04_.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_.Context
{
    internal class ITIContext: DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Emp> Employees { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DbTest2;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(x =>
            {
                // "tpc" table oer concrete class >>> to create tables for concrete classes (emp, student) instead of one big table for all classes including person
                x.UseTpcMappingStrategy();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
