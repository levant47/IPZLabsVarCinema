using System;

namespace IPZLabsVarCinema
{
    public record Session
    (
        int Id,
        int MovieId,
        int HallId,
        DateTime StartTime,
        decimal PopcornAmount,
        int Glasses3DAmount,
        decimal DrinksAmount,
        bool CleaningFinished,
        bool LightingSetup,
        bool CameraChecked
    );
}
