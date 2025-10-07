using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_entities_to_DB.Models
{
    internal class Course
    {
        public int CrsId { get; set; }
        public string CrsName { get; set; }
        public int CrsHours { get; set; }

        [NotMapped] // don't create column for "xyz" in the database (ex: confirm password in forms)
        public int xyz { get; set; }


        // relation between department and course (many to many)
        public virtual List<Department> Departments { get; set; } = new List<Department>(); // navigation property

        // relation between student and course (many to many) and the new table has property "degree"
        public virtual List<StudentCourse> CourseStudents { get; set; } = new List<StudentCourse>();
    }
}
