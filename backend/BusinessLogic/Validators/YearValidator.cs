using System;

namespace IPZLabsVarCinema
{
    public static class YearValidator
    {
        public static void AssertValid(int year, string name)
        {
            if (!(year >= 1900 && year <= 2100))
            {
                throw new ArgumentException("Year values must be in range 1900-2100", name);
            }
        }
    }
}
