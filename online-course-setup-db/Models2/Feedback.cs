using System;
using System.Collections.Generic;

namespace online_course_setup_db.Models2;

public partial class Feedback

{
    public Feedback(string? Comment, int? CourseId, int? Rating, int? userId)
    {
        this.Comment = Comment;
        this.CourseId = CourseId;
        this.Rating = Rating;
        this.UserId = userId;
    }

    public int Id { get; set; }

    public string? Comment { get; set; }

    public int? Rating { get; set; }

    public int? CourseId { get; set; }

    public int? OrderDetailId { get; set; }

    public int? UserId { get; set; }

    public virtual Course? Course { get; set; }

    public virtual OrderDetail? OrderDetail { get; set; }

    public virtual User? User { get; set; }
}
