using System;

namespace IPZLabsVarCinema
{
    public record TicketVM
    (
        string MovieName,
        DateTime SessionStartTime,
        string HallName,
        int Row,
        int Seat
    );
}
