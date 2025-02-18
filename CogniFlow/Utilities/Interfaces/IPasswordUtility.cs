namespace CogniFlow.Utilities.Interfaces
{
    public interface IPasswordUtility
    {
        string HashPassword(string password, string salt);
        bool VerifyPassword(string hashedPassword, string password);
        string GenerateSalt();
    }
}
