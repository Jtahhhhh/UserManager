using System.Security.Cryptography;


namespace LoginApi.Models
{
    public class HashPassword: Interface

    {
        private const int SaltSize = 124 / 8;
        private const int keySize = 256/8;
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA256;
        private static char delimeter = ';';
        public string Hash (string password)
        {
            var salt= RandomNumberGenerator.GetBytes(SaltSize); 
            var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt,Iterations,_hashAlgorithm,keySize);
        
            return string.Join(delimeter,Convert.ToBase64String(salt) ,Convert.ToBase64String(hash));
        }
    }
}
