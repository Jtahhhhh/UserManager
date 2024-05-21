namespace LoginApi.Models
{
    public interface Interface
    {
        
            string Hash(string password);
            bool VerifyPassword(string passwordHash, string inputPassword);
        
    }
}
