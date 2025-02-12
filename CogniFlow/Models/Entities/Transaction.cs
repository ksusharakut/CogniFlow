namespace CogniFlow.Models.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public int UserId { get; set; }
        public int CourseId { get; set; }

        public User User { get; set; }
        public Course Course { get; set; }
    }
}
