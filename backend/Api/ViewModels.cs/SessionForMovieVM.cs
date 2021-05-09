using System;

namespace IPZLabsVarCinema
{
    public record SessionForMovieVM
    (
        int Id,
        string HallName,
        DateTime StartTime,
        int SeatsOccupied,
        int SeatsTotal
    );
}
