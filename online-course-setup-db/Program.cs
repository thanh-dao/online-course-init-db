////// e https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using online_course_setup_db.Models2;

Console.WriteLine(1);
CourseOnlineContext context = new CourseOnlineContext();
HttpClient request = new HttpClient();
int[] slots = { 15, 20, 30 };
var categories = new String[9]
{
    "java",
    "javascript",
    "go",
    "rust",
    "dart",
    "python",
    "flutter",
    "c#",
    "c++"
};

if (!context.Courses.Any())
{
    List<Course> Courses = new List<Course>();
    using (StreamReader r = new StreamReader("Courses.json"))
    {
        string json = r.ReadToEnd();
        Courses = JsonConvert.DeserializeObject<List<Course>>(json);

        context.Courses.AddRangeAsync(Courses);
        context.SaveChanges();
    }
    Random random = new Random();
    context.Courses.ToList().ForEach(c =>
    {
        c.Slot = slots[random.Next(slots.Length)];
        if (c.Objective.Equals(""))
        {
            c.Objective = c.CourseName;
        }

        context.SaveChanges();
    });
}

if (!context.Users.Any())
{
    context.Users.AddRangeAsync(new List<User>()
    {
        new User("student 1", "thanh092001@hoho.com","thanh", "123456", "0123586904", "student"),
        new User("student 2", "thanhdd1068@gmail.com", "123456", "0123586904", "student"),
        new User("student 3", "ThinhPT0624@gmail.com", "123456", "0123586904", "student"),
        new User("student 4", "ThuyPTP0542@gmail.com", "123456", "0123586904", "student"),
        new User("student 5", "ThuyVTM0510@gmail.com", "123456", "0123586904", "student"),
        new User("student 6", "TienNT0768@gmail.com", "123456", "0123586904", "student"),
        new User("student 7", "TrangNPH0074@gmail.com", "123456", "0123586904", "student"),
        new User("student 8", "TraPT0660@gmail.com", "123456", "0123586904", "student"),
        new User("student 9", "TrinhDTP0860@gmail.com", "123456", "0123586904", "student"),
        new User("student 10", "MinhTH08@gmail.com", "123456", "0123586904", "student"),
        new User("student 11", "phinh0972@gmail.com", "123456", "0123586904", "student"),
        new User("student 12", "PhucNDT0625@gmail.com", "123456", "0123586904", "student"),
        new User("student 13", "TungTT0623@gmail.com", "123456", "0123586904", "student"),
    });
    context.SaveChanges();
}
if (!context.Feedbacks.Any())
{
    List<Feedback> feedbacks = new List<Feedback>();
    using (StreamReader r = new StreamReader("reviews.json"))
    {
        string json = r.ReadToEnd();
        feedbacks = JsonConvert.DeserializeObject<List<Feedback>>(json);
        context.AddRangeAsync(feedbacks);

        context.SaveChanges();
    }
}