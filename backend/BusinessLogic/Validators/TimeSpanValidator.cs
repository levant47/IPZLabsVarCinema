using System;

namespace IPZLabsVarCinema
{
    public static class TimeSpanValidator
    {
        public static void AssertValid(TimeSpan value, string name)
        {
            if (value.TotalHours == 0 || value.TotalHours >= 24)
            {
                throw new ArgumentException("Time span is expected to be in range from 0-24 hours", name);
            }
        }
    }
}
