namespace CogniFlow.Utilities.Interfaces
{
    public interface IPasswordHandler
    {
        string HashPassword(string password, string salt);
        bool VerifyPassword(string hashedPassword, string password);
        string GenerateSalt();
    }
}
