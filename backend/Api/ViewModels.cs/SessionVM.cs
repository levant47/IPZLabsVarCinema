using System;

namespace IPZLabsVarCinema
{
    public record SessionVM
    (
        int Id,
        string HallName,
        DateTime StartTime,
        int SeatsOccupied,
        int SeatsTotal
    );
}
