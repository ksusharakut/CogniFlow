namespace CogniFlow.Models.Entities
{
    public class Module
    {
        public int ModuleId { get; set; }
        public int CourseId { get; set; }
        public int OrderIndex { get; set; }
        public string Title { get; set; }
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        public Course Course { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
