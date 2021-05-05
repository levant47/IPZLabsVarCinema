using System;

namespace IPZLabsVarCinema
{
    public record User
    (
        int Id,
        string FirstName,
        string LastName,
        string Email,
        DateTime RegistrationTime,
        byte[] Password,
        Role Role
    );
}
