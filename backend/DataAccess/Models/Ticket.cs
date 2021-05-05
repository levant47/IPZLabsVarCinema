using System;

namespace IPZLabsVarCinema
{
    public record Ticket
    (
        int Id,
        int UserId,
        int SessionId,
        int SeatRow,
        int SeatIndex,
        DateTime PurchaseTime
    );
}
