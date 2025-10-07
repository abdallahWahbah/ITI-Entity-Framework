using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_entities_to_DB.Models
{
    internal class StudentCourse

    {
        // we created this class cause relation between std, crs is (many to many) (new table "StudentCourse")
        // and the new table may have properties like "degree", so now it's mandatory to create this entity by hand not navigation property

        public int StudentId {  get; set; } // remains only to indicate that (StudentId and CourseId) are composite pk (only by fluent api)
        public int CourseId { get; set; }
        public int? degree { get; set; } // don't forget to make relation (navigation properties) in student and course entities

        // relations
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
