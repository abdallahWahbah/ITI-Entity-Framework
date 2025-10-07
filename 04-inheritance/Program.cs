using _04_.Context;
using _04_.Models;
using Microsoft.EntityFrameworkCore;

namespace _04_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // when using inheritance, all classes in the hirarichy are put in one table
            // Person, Emp, Student >>> it will create only table for People(parent) and will add a new column called "Discriminator" (child type: Emp, Students) so that it when what child object you inserted

            // but we need to make tables for each concrete class (emp, student), so we will use "UseTpcMappingStrategy" in fluent api and make Person abstract
            // after using "UseTpcMappingStrategy", every child class will have parent properties (Id, Name, Age)

            using (ITIContext db = new ITIContext())
            {
                //db.Database.EnsureDeleted(); // delete the db
                //db.Database.EnsureCreated();


                ///////////////////////////////////////////// before separating each entity in a separate tabel in the fluent api

                //Student student1 = new Student() { Id = 1, Age = 20, Name = "Abdallah", Grade = 'A' };
                //Student student2 = new Student() { Id = 2, Age = 30, Name = "Mahmoud", Grade = 'B' };
                //Emp emp1 = new Emp() { Id = 20, Age = 25, Name = "Wahbah", Salary = 10000 };
                //Emp emp2 = new Emp() { Id = 21, Age = 26, Name = "Wahbah__2", Salary = 9000 };
                //Console.WriteLine(db.Entry(student1).State); // Detached
                //Console.WriteLine(db.Entry(emp1).State); // Detached
                //db.Employees.Add(emp1);
                //db.Employees.Add(emp2);
                //db.Students.Add(student1);
                //db.Students.Add(student2);
                //Console.WriteLine(db.Entry(student1).State); // Added
                //Console.WriteLine(db.Entry(emp1).State); // Added

                //db.SaveChanges();

                // OfType
                Console.WriteLine(db.People.OfType<Person>().Count());
                Console.WriteLine(db.People.OfType<Emp>().Count());
                Console.WriteLine(db.People.OfType<Student>().Count());
                var stds = db.People.OfType<Student>().ToList();
                foreach(var std in stds) Console.Write($"{std.Name}, "); // Abdallah, Mahmoud



                //// if you want to change table row locally in c# app and not modifying it in db even if you db.SaveChanges
                //var stds2 = db.People.OfType<Student>().AsNoTracking();
                //var std1 = db.Students.AsNoTracking().FirstOrDefault(x => x.Id == 1);
                //std1.Name = "asdlkakjsddlajsd";
                //db.SaveChanges(); // will not affect the db
            }
        }
    }
}
