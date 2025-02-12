namespace CogniFlow.Models.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsPublished {  get; set; }

        public virtual User User { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public ICollection<Module> Modules { get; set; }
    }
}
