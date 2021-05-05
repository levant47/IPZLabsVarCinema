using System;
using System.Linq;

namespace IPZLabsVarCinema
{
    public static class NameValidator
    {
        public static void AssertValid(string value, string name)
        {
            NonEmptyStringValidator.AssertValid(value, name);

            if (!char.IsUpper(value[0]))
            {
                throw new ArgumentException("Names must begin with a capital letter", name);
            }

            if (!value.All(char.IsLetter))
            {
                throw new ArgumentException("Names must only contain letters", name);
            }
        }
    }
}
