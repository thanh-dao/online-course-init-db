using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace online_course_setup_db.Models2;

public partial class Category
{
    public Category(string? CategoryName)
    {
        this.CategoryName = CategoryName;
    }
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [IgnoreDataMember]
    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }

}
