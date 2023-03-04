using System;
using System.Collections.Generic;

namespace online_course_setup_db.Models2;

public partial class Order
{
    public int Id { get; set; }

    public DateTime? BuyDate { get; set; }

    public string? Coupon { get; set; }

    public string? PaymentId { get; set; }

    public string? PaymentMethod { get; set; }

    public bool? PaymentStatus { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual User? User { get; set; }
}
