using System.Collections.Generic;

namespace IPZLabsVarCinema
{
    public interface ISessionsService
    {
        List<SessionDto> GetCurrentSessionsForMovie(int movieId);

        SessionDto GetById(int sessionId);

        SessionDto Update(SessionDto updatedSession);
    }
}
