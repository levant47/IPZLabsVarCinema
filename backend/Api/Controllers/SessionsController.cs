using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IPZLabsVarCinema
{
    [Route("api/[controller]")]
    public class SessionsController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;

        public SessionsController(CinemaDbContext dbContext) => _dbContext = dbContext;

        [HttpGet("currentForMovie")]
        public object GetCurrentForMovie([FromQuery] int movieId) => _dbContext.Sessions
            .Where(session => session.MovieId == movieId)
            .Select(session => new SessionVM
            (
                /* Id: */ session.Id,
                /* HallName: */ session.Hall.Name,
                /* StartTime: */ session.StartTime,
                /* SeatsOccupied: */ session.Tickets.Count,
                /* SeatsTotal: */ session.Hall.SeatRowCount * session.Hall.SeatRowSize
            ))
            .ToList()
            .OrderBy(session => session.StartTime)
            .ToList();
    }
}
