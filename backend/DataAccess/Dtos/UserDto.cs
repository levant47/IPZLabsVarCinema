using System;

namespace IPZLabsVarCinema
{
    public record UserDto
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
