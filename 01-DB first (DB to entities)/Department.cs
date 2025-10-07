using System;
using System.Collections.Generic;

namespace _01_;

public partial class Department
{
    public int DeptId { get; set; }

    public string? DeptName { get; set; }

    public string? DeptDesc { get; set; }

    public string? DeptLocation { get; set; }

    public int? DeptManager { get; set; }

    public DateOnly? ManagerHiredate { get; set; }

    public virtual Instructor? DeptManagerNavigation { get; set; }

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public override string ToString()
    {
        return $"Dept No: {DeptId}, Name: {DeptName}";
    }
}
