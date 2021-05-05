using System;

namespace IPZLabsVarCinema
{
    public static class PositiveNumberValidator
    {
        public static void AssertValid(int value, string name)
        {
            if (value <= 0)
            {
                throw new ArgumentException("Expected positive integer value", name);
            }
        }
    }
}
