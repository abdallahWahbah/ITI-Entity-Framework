using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_.Models
{
    public abstract class Person
    {
        // when using inheritance, all classes in the hirarichy are put in one table
        // Person, Emp, Student >>> it will create only table for People(parent) and will add a new column called "Discriminator" (child type: Emp, Students) so that it when what child object you inserted

        // but we need to make tables for each concrete class (emp, student), so we will use "UseTpcMappingStrategy" in fluent api and make Person abstract
        // after using "UseTpcMappingStrategy", every child class will have parent properties (Id, Name, Age)

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class Emp: Person
    {
        public int Salary { get; set; }
    }
    public class Student: Person
    {
        public char Grade { get; set; }
    }
}
