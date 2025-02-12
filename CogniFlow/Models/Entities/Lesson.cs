using CogniFlow.Models.Enums;

namespace CogniFlow.Models.Entities
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string ContentPath { get; set; }
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public int OrderIndex { get; set; }
        public LessonType LessonType { get; set; }

        public Module Module { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
