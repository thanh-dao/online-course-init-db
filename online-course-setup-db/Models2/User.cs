using System;
using System.Collections.Generic;

namespace online_course_setup_db.Models2;

public partial class User
{
    public User(string? description, string? email, string? fullname, string? password, string? phone, string? role)
    {
        Description = description;
        Email = email;
        Fullname = fullname;
        Password = password;
        Phone = phone;
        Role = role;
    }

    public User(string? description, string? email, string? password, string? phone, string? role)
    {
        Description = description;
        Email = email;
        Fullname = email.Replace("@gmail.com", "");
        Password = password;
        Phone = phone;
        Role = role;
    }

    public int Id { get; set; }

    public string? Description { get; set; }

    public string? Email { get; set; }

    public string? Fullname { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Course> CourseCreateByNavigations { get; } = new List<Course>();

    public virtual ICollection<Course> CourseLastUpdateUserNavigations { get; } = new List<Course>();

    public virtual ICollection<Course> CourseTeachers { get; } = new List<Course>();

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
