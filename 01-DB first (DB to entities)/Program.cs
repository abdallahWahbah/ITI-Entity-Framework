using Microsoft.EntityFrameworkCore;

namespace _01_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1- connect to DB
            // 2- install Microsoft.EntityFrameworkCore.SqlServer, Microsoft.EntityFrameworkCore.Tools (right click on solution,  Manage Nuget..)
            // open package Manager Console (if not exist >>> tools >Nuget package manager, package manager console)
            // ######################### write
            // Scaffold-DbContext "yourConnectionString" microsoft.entityframeworkcore.sqlserver
            // it will create entities for all db tables and relations between them

            // if you want to change the context name >> increase the following line to the query
            // -context NewContextName

            // if you want to add the Context in a folder >> increase the following line to the query
            // -contextdir ContextFolder

            // if you want to add the entities in a folder >> increase the following line to the query
            // -outputdir EntitiesFolder

            // ----------------------------- the query -----------------------------
            // Scaffold-DbContext "Data Source=.;Initial Catalog=ITI;Integrated Security=True;Encrypt=True;Trust Server Certificate=True" microsoft.entityframeworkcore.sqlserver -context TestContext -contextdir testContextFolder -outputdir testOutputFolder


            ItiContext db = new ItiContext();


            // reading all depts
            var departments = db.Departments;
            Console.WriteLine(departments.ToQueryString()); // SELECT [d].[Dept_Id], [d].[Dept_Desc], [d].[Dept_Location], [d].[Dept_Manager], [d].[Dept_Name], [d].[Manager_hiredate] FROM[Department] AS[d]
            foreach (var dept in departments)
            {
                Console.WriteLine(dept); // i overrode ToString()
            }


            // reading all depts with condition
            var departments2 = db.Departments.Where(a => a.DeptName.StartsWith("a")).Select(b => new { b.DeptName, b.DeptManager});
            Console.WriteLine(departments2.ToQueryString()); // SELECT [d].[Dept_Name] AS [DeptName], [d].[Dept_Manager] AS [DeptManager] FROM[Department] AS[d] WHERE[d].[Dept_Name] LIKE N'a%'


            // update single dept, affect the db
            var EL_dept = db.Departments.FirstOrDefault(dept => dept.DeptName == "EL");
            Console.WriteLine(EL_dept); // Dept No: 20, Name: EL (i overrode ToString())
            EL_dept.DeptManager = 11; // will be sacved only in memory not the real DB
            db.SaveChanges(); // now it will affect the DB
            Console.WriteLine(EL_dept.DeptManager); // 11


            //// insert new dept
            //db.Departments.Add(new Department() { DeptId = 1, DeptName = "Accounting", DeptDesc = "new desctiption"});
            //db.SaveChanges();


            //// remove dept
            //var accountingDept = db.Departments.FirstOrDefault(a => a.DeptName == "Accounting");
            //Console.WriteLine(db.Entry<Department>(accountingDept).State); // Unchanged
            //db.Departments.Remove(accountingDept);
            //Console.WriteLine(db.Entry<Department>(accountingDept).State); // Deleted
            //db.SaveChanges();
        }
    }
}
