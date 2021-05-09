using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IPZLabsVarCinema
{
    public class SessionsController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;

        public SessionsController(CinemaDbContext dbContext) => _dbContext = dbContext;

        [HttpGet("{movieId}")]
        public object GetCurrentForMovie([FromRoute] int movieId) => _dbContext.Sessions.Where(session => session.MovieId == movieId).ToList();
    }
}
