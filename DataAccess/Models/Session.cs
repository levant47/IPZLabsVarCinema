namespace IPZLabsVarCinema
{
    public record Session
    (
        int Id,
        int MovieId,
        int HallId,
        DateTime StartTime
    );
}
