namespace CogniFlow.DTOs
{
    public class UserUpdateDTO
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateOnly? DateBirth { get; set; }
        public string Email { get; set; }
    }
}
