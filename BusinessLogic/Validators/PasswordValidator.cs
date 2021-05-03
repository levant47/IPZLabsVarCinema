using System.Linq;

namespace IPZLabsVarCinema
{
    public static class PasswordValidator
    {
        public static void AssertValid(string password)
        {
            if (password.Length < 8)
            {
                throw new PasswordValidationException("Password must be at least 8 characters in length");
            }

            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower))
            {
                throw new PasswordValidationException("Password must contain a mixture of both upper and lower case letters");
            }

            if (!password.Any(char.IsDigit))
            {
                throw new PasswordValidationException("Password must contain both letters and numbers");
            }
        }
    }
}
