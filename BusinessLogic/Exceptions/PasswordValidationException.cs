using System;

namespace IPZLabsVarCinema
{
    public class PasswordValidationException : Exception
    {
        public PasswordValidationException() { }

        public PasswordValidationException(string message) : base(message) { }

        public PasswordValidationException(string message, Exception inner) : base(message, inner) { }
    }
}
