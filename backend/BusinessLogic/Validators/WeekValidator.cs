using System;
using System.Globalization;

namespace IPZLabsVarCinema
{
    public static class WeekValidator
    {
        public static void AssertValid(int week, int year, string name)
        {
            var numberOfWeeksInYear = GetNumberOfWeeksInYear(year);
            if (!(week >= 1 && week <= numberOfWeeksInYear))
            {
                throw new ArgumentException("Week value out of range for given year", name);
            }
        }

        private static int GetNumberOfWeeksInYear(int year)
        {
            var dfi = DateTimeFormatInfo.CurrentInfo;
            return dfi.Calendar.GetWeekOfYear(new DateTime(year, 12, 31), dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }
    }
}
