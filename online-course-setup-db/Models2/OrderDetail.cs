using System;
using System.Collections.Generic;

namespace online_course_setup_db.Models2;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int? Price { get; set; }

    public int? CourseId { get; set; }

    public int? OrderId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual Order? Order { get; set; }
}
