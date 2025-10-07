using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_entities_to_DB.Models
{
    [Table("Students")] // the table in DB will ne "Students" not "Student"
    internal class Student
    {
        public int StdId { get; set; } // not name convension // not primary key >>> you can use data annotation [Kye] or fluent api
        //[Column("DbName")] // if you used this annotation, the Name column will be DbName in the DB
        [StringLength(20)]
        [Required]
        public string Name { get; set; }
        public int? Age { get; set; }


        // relation between department with student (1 to many)
        [ForeignKey("Department")] // to indicate that "DeptNo" is the FK for Department table (for my logic use: not mandatory)
        public int DeptNo { get; set; }
        public virtual Department Department { get; set; } // navigation property

        // relation between student and course (many to many) and the new table has property "degree"
        public virtual List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
