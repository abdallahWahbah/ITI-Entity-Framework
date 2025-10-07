using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_entities_to_DB.Models
{
    public class Department
    {
        public int Id { get; set; } // must be "Id" or "DepartmentId" to be a primary key (naming convension) 

        // or if you insist to name the primary key as "deptId", you can use the data annotation
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] //  not identit (no auto increment)
        // you can combine both together [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int DeptId { get; set; }

        [Required] // don't allow null
        [StringLength(20)] // or [MaxLength(20)]
        // simpley >> [Required, StringLength(20)]
        public string DeptName { get; set; }

        public int? Capacity { get; set; } // "?" to allow null in the database


        ////////////////////////
        // relations // to make relation, we use navigation properties only 
        ////////////////////////
        
        // relation between department with student (1 to many)
        public virtual List<Student> Students { get; set; } = new List<Student>(); // Navigation property 


        // relation between department and course (many to many) (it will create CourseDepartment table by itself)
        public virtual List<Course> Courses { get; set; } = new List<Course>(); // Navigation property 
    }
}
