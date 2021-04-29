using System.Security.Cryptography;
using System.Text;

namespace IPZLabsVarCinema
{
    public static class PasswordEncoder
    {
        public static byte[] Encode(string password)
        {
            using var sha256 = SHA256.Create();
            return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }
}
