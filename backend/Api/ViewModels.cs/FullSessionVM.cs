using System;
using System.Collections.Generic;

namespace IPZLabsVarCinema
{
    public record FullSessionVM
    (
        int Id,
        DateTime StartTime,
        string MovieName,
        string HallName,
        int HallSeatRowCount,
        int HallSeatRowSize,
        List<int> OccupiedSeats
    );
}
