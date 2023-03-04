using System;
using System.Collections.Generic;

namespace online_course_setup_db.Models2;

public partial class Course
{
    public int Id { get; set; }

    public string? CourseName { get; set; }

    public string? Description { get; set; }

    public DateTime? EndDate { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? Objective { get; set; }

    public int? Slot { get; set; }

    public DateTime? StartDate { get; set; }

    public bool? Status { get; set; }

    public string? Suitable { get; set; }

    public int? TuitionFee { get; set; }

    public int? CreateBy { get; set; }

    public int? LastUpdateUser { get; set; }

    public int? TeacherId { get; set; }

    public virtual User? CreateByNavigation { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual User? LastUpdateUserNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual User? Teacher { get; set; }

    public virtual ICollection<Category> Categories { get; } = new List<Category>();
}
