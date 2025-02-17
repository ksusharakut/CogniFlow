namespace CogniFlow.DTOs
{
    public class UserRegisterDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateOnly DateBirth { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
