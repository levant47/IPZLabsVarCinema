using System;

namespace IPZLabsVarCinema
{
    public class InvalidSeatNumberException : Exception
    {
        public InvalidSeatNumberException() { }

        public InvalidSeatNumberException(string message) : base(message) { }

        public InvalidSeatNumberException(string message, Exception inner) : base(message, inner) { }
    }
}
