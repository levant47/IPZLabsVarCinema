using System;

namespace IPZLabsVarCinema
{
    public static class NonEmptyStringValidator
    {
        public static void AssertValid(string? value, string name)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Expected a non-empty string", name);
            }
        }
    }
}
