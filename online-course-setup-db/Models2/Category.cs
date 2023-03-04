using System;
using System.Collections.Generic;

namespace online_course_setup_db.Models2;

public partial class Category
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
