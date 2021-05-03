using System;

namespace IPZLabsVarCinema
{
    public static class DateTimeValidator
    {
        public static void AssertValid(DateTime value, string name)
        {
            YearValidator.AssertValid(value.Year, name);
        }
    }
}
