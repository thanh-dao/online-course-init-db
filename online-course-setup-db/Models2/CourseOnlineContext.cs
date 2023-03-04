using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace online_course_setup_db.Models2;

public partial class CourseOnlineContext : DbContext
{
    public CourseOnlineContext()
    {
    }

    public CourseOnlineContext(DbContextOptions<CourseOnlineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=course_online;Trusted_Connection=True;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__category__3213E83FED072C64");

            entity.ToTable("category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryName)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__course__3213E83F022E2222");

            entity.ToTable("course");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseName)
                .IsUnicode(false)
                .HasColumnName("course_name");
            entity.Property(e => e.CreateBy).HasColumnName("create_by");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.ImageUrl)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.LastUpdateDate).HasColumnName("last_update_date");
            entity.Property(e => e.LastUpdateUser).HasColumnName("last_update_user");
            entity.Property(e => e.Objective)
                .IsUnicode(false)
                .HasColumnName("objective");
            entity.Property(e => e.Slot).HasColumnName("slot");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Suitable)
                .IsUnicode(false)
                .HasColumnName("suitable");
            entity.Property(e => e.TeacherId).HasColumnName("teacher_id");
            entity.Property(e => e.TuitionFee).HasColumnName("tuition_fee");

            entity.HasOne(d => d.CreateByNavigation).WithMany(p => p.CourseCreateByNavigations)
                .HasForeignKey(d => d.CreateBy)
                .HasConstraintName("FK5h47t099nvhjsneyx82mjq2hg");

            entity.HasOne(d => d.LastUpdateUserNavigation).WithMany(p => p.CourseLastUpdateUserNavigations)
                .HasForeignKey(d => d.LastUpdateUser)
                .HasConstraintName("FK8h9fl48n6a7wrtlxn5yviigu9");

            entity.HasOne(d => d.Teacher).WithMany(p => p.CourseTeachers)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FKbhmlx82vjuwypl8dmfnrbjfhu");

            entity.HasMany(d => d.Categories).WithMany(p => p.Courses)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoryCourse",
                    r => r.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKl8684hm4omct596rcrjpvttiv"),
                    l => l.HasOne<Course>().WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FKovppma1bgjyuov5c69wd3w387"),
                    j =>
                    {
                        j.HasKey("CoursesId", "CategoriesId").HasName("PK__category__EEEF9EC378D10193");
                        j.ToTable("category_course");
                        j.IndexerProperty<int>("CoursesId").HasColumnName("courses_id");
                        j.IndexerProperty<int>("CategoriesId").HasColumnName("categories_id");
                    });
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__feedback__3213E83F5B36BDAA");

            entity.ToTable("feedback");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Course).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FKko7f08v61t5y67teh5jxxwrea");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.OrderDetailId)
                .HasConstraintName("FK88hp1ug23wm12cr9kb5ufffkf");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FKpwwmhguqianghvi1wohmtsm8l");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orders__3213E83F97A30261");

            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BuyDate).HasColumnName("buy_date");
            entity.Property(e => e.Coupon)
                .IsUnicode(false)
                .HasColumnName("coupon");
            entity.Property(e => e.PaymentId)
                .IsUnicode(false)
                .HasColumnName("payment_id");
            entity.Property(e => e.PaymentMethod)
                .IsUnicode(false)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus).HasColumnName("payment_status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK32ql8ubntj5uh44ph9659tiih");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__order_de__3213E83F121C64EA");

            entity.ToTable("order_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Course).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FKd81apmag4lbo3gw9b3n8myokq");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FKrws2q0si6oyd6il8gqe2aennc");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FB86CA7C3");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Fullname)
                .IsUnicode(false)
                .HasColumnName("fullname");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
