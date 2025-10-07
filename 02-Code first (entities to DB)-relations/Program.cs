using _02_entities_to_DB.Context;

namespace _02_entities_to_DB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // to map you entity (ex: departments) to DB 
            // install microsoft.entityframework.sqlserver, microsoft.entityframework.tools
            // create the departments, student entities
            // create ITIContext
            // open package Manager Console (if not exist >>> tools >Nuget package manager, package manager console)
            // (to affect the db: use microsoft.entityframework.tools) and write >>> add-migration m1 >>>> then >>> update-database


            // using the user-defined ITIContext
            using (ITIContext db = new ITIContext()){
                //var dept1 = db.Departments.FirstOrDefault(x => x.Id == 1);
                //db.Students.Add(new Models.Student() { Name = "hanaa", Department = dept1 });
                db.Students.Add(new Models.Student() { Name = "hanaa", DeptNo = 1}); // easier

                db.SaveChanges();

            }

            // after migration and updating database, to see the tables with relations in sql server management studio
            // right click on db, refesh, expand db, right click on Database Diagrams, New Database Diagram, Refresh, select all tables
        }
    }
}
