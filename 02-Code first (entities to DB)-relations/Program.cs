using _02_entities_to_DB.Context;
using _02_entities_to_DB.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_entities_to_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // to map entity (ex: departments) to DB 
            // install microsoft.entityframework.sqlserver, microsoft.entityframework.tools
            // create the departments, student entities
            // create ITIContext
            // open package Manager Console (if not exist >>> tools >Nuget package manager, package manager console)
            // (to affect the db: use microsoft.entityframework.tools) and write >>> add-migration m1 >>>> then >>> update-database


            // using the user-defined ITIContext
            using (ITIContext db = new ITIContext()){
                ////var dept1 = db.Departments.FirstOrDefault(x => x.Id == 1);
                ////db.Students.Add(new Models.Student() { Name = "hanaa", Department = dept1 });
                //db.Students.Add(new Models.Student() { Name = "hanaa", DeptNo = 1}); // easier

                //db.SaveChanges();


                //// Eager load, Include, ThenInclude
                //// if you tried to access Department navigation property in Student, it will give you null
                //// so we need to Incude it (eager load) (Include, ThenInclude affect the performance)
                //var res = db.Students
                //            .Include(a => a.Department)
                //            .ThenInclude(a => a.Courses) // now "a" refers to the Department not Student
                //            //.Include(b => b.StudentCourses) // now "b" refers back to the Student
                //            .FirstOrDefault(a => a.StdId == 1);
                //Console.WriteLine(res.Name);
                //Console.WriteLine(res.Department.DeptName);


                //// Explicit Load
                //var res4 = db.Students.FirstOrDefault(a => a.StdId == 1); // not res4.Department ===== null
                //db.Entry<Student>(res4).Reference(a => a.Department).Load(); // add the department data to student
                //db.Entry<Student>(res4).Collection(a => a.StudentCourses).Load(); // if the data i wanna load is list, we use Collection instead of Reference
                //Console.WriteLine(res4.Department.DeptName);


                // Lazy load: get the original data, when reading the navigation properties, it makes a new request
                // 1- navigation property must be virtual
                // 2- install library (Microsoft.EntityFrameworkCore.Proxies)
                // 3- in the context OnConfiguring function, UseLazyLoadingProxies()

                var depts = db.Departments.FirstOrDefault(d => d.Id == 1); // it will load only the related data (Id, Capacity, DeptName)
                foreach(var item in depts.Students) // now it will make another query to load the students
                {
                    Console.WriteLine(item.Name);
                }

            }

            // after migration and updating database, to see the tables with relations in sql server management studio
            // right click on db, refesh, expand db, right click on Database Diagrams, New Database Diagram, Refresh, select all tables
        }
    }
}
