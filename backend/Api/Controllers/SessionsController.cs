using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            .Select(session => new SessionForMovieVM
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

        [HttpGet("{sessionId}/view")]
        public object GetSessionViewById([FromRoute] int sessionId) => _dbContext.Sessions
            .Include(session => session.Movie)
            .Include(session => session.Hall)
            .Include(session => session.Tickets)
            .Where(session => session.Id == sessionId)
            .ToList()
            .Select(session => new FullSessionVM
            (
                /* Id: */ session.Id,
                /* StartTime: */ session.StartTime,
                /* MovieName: */ session.Movie.Name,
                /* HallName: */ session.Hall.Name,
                /* HallSeatRowCount: */ session.Hall.SeatRowCount,
                /* HallSeatRowSize: */ session.Hall.SeatRowSize,
                /* OccupiedSeats: */ session.Tickets.Select(ticket => (ticket.SeatRow - 1) * session.Hall.SeatRowSize + ticket.SeatIndex).ToList()
            ))
            .FirstOrDefault();
    }
}
