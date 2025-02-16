namespace CogniFlow.DTOs
{
    public class UserReturnDTO
    {
        public int UserId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateOnly DateBirth { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
