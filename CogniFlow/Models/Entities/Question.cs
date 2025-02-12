using CogniFlow.Models.Enums;

namespace CogniFlow.Models.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int LessonId { get; set; }
        public string Text { get; set; }
        public QuestionType QuestionType { get; set; }
        public int OrderIndex { get; set; }

        public Lesson Lessons { get; set; }
        public ICollection<AnswerOption> AnswerOptions { get; set; }
    }
}
