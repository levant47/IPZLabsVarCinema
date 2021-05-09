using System;
using System.Collections.Generic;

namespace IPZLabsVarCinema
{
    public record Session
    (
        int Id,
        int MovieId,
        int HallId,
        DateTime StartTime
    )
    {
        public Hall Hall { get; set; } = null!;

        public Movie Movie { get; set; } = null!;

        public List<Ticket> Tickets { get; set; } = null!;
    }
}
