using _02_entities_to_DB.Config;
using _02_entities_to_DB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_entities_to_DB.Context
{
    internal class ITIContext: DbContext
    {
        // to migrate your entity to DB, you must wrap it with DbSet<YourEntity>
        public DbSet<Department> Departments { get; set; } // "Departments" is the table name 
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=.;database=DbTest;integrated security=true; trust server certificate=true"); // write this string connection by yourself or get it from server explorer
            base.OnConfiguring(optionsBuilder);
        }
        // after finishing your work
        // open package Manager Console (if not exist >>> tools >Nuget package manager, package manager console)
        // write add-migration m1
        // then write update-database
        // go to sql server, disconnect, connect, you will see "DbTest" data base and Departments table inside of it

        // if you added the migration and not affected the db yet (update-database) >>> write remove-migration


        // to setup your properties, you use naming convension or data annotation or fluent api
        // fluent api (highest priority when conflict with convension or annotation)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //// initial data
            //modelBuilder.Entity<Department>(dept =>
            //{
            //    dept.HasData(
            //        new Department() { Id = 100, },
            //        new Department() { Id = 110, },
            //        new Department() { Id = 120, }
            //    );
            //});
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // composite primary key for student-course relation
            modelBuilder.Entity<StudentCourse>(c =>
            {
                c.HasKey(s => new { s.StudentId, s.CourseId }); 
            });

            //// building dept-student relation using fluent expression 
            //modelBuilder.Entity<Department>(c =>
            //{
            //    c.HasMany(d => d.Students)
            //    .WithOne(s => s.Department)
            //    .HasForeignKey(s => s.DeptNo)
            //    .IsRequired();
            //});
            //// or
            //modelBuilder.Entity<Student>(s =>
            //{
            //    s.HasOne(s => s.Department)
            //    .WithMany(d => d.Students)
            //    .HasForeignKey(x => x.DeptNo)
            //    .IsRequired();
            //});


            //// building dept-course relation using fluent expression
            //modelBuilder.Entity<Department>(d =>
            //{
            //    d.HasMany(x => x.Courses)
            //    .WithMany(x => x.Departments);
            //});

            modelBuilder.Entity<Student>(std =>
            {
                std.HasKey(s => s.StdId);
                std.Property(s => s.Name).HasMaxLength(20).IsRequired();
                std.Property(s => s.Age).IsRequired(false); // it will allow null in the DB

            });

            // set relation using fluent expression
            //modelBuilder.Entity<Student>().HasOne(s => s.Department).WithMany(d => d.Students).HasForeignKey(s => s.DeptNo);

            modelBuilder.Entity<Course>(course =>
            {
                //course.ToTable("Students"); // naming the table in the DB using fluent api
                course.HasKey(c => c.CrsId);
                course.Property(c => c.CrsId).ValueGeneratedNever(); // not identity (not auto increment)
                //course.Property(c => c.CrsId).ValueGeneratedOnAdd(); // identity (auto increment)
                course.Property(c => c.CrsName).HasMaxLength(50).IsRequired();

                //course.Ignore(x => x.xyz); // don't create column for "xyz" using fluent api
            });



            ////// in real-world projects, we make a folder for configurations for entities and import it in this function
            ////modelBuilder.ApplyConfiguration<Student>(new StudentConfig());
            
            //// if you have too many configuration files, it's not reasonable to copy-paste the line above 100 times for example
            //// you can use "ApplyConfigurationsFromAssembly"
            //// it will add all config files in the project automatically using the .dll file // they all have the same Assembly
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfig).Assembly); 

            base.OnModelCreating(modelBuilder);


            // don't forget to write add-migration m4, update-database
        }
    }
}
