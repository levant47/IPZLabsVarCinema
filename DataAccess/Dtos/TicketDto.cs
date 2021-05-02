using System;

namespace IPZLabsVarCinema
{
    public record TicketDto
    (
        int Id,
        int UserId,
        int SessionId,
        int SeatRow,
        int SeatIndex,
        DateTime PurchaseTime
    );
}
