namespace IPZLabsVarCinema
{
    public record Ticket
    (
        int Id,
        int UserId,
        int Session,
        int SeatRow,
        int SeatIndex,
        DateTime PurchaseTime
    );
}
