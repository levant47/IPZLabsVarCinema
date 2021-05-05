using System;

namespace IPZLabsVarCinema
{
    public record Shift
    (
        int Id,
        DateTime StartTime,
        TimeSpan Duration
    );
}
