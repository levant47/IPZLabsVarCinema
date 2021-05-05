using System;
using System.Text.RegularExpressions;

namespace IPZLabsVarCinema
{
    public static class EmailValidator
    {
        private static readonly Regex _emailRegex = new(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");

        public static void AssertValid(string email, string name)
        {
            if (!_emailRegex.IsMatch(email))
            {
                throw new ArgumentException("Ill-formatted email", name);
            }
        }
    }
}
