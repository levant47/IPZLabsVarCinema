using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace IPZLabsVarCinema
{
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly CinemaDbContext _dbContext;

        public MoviesController(CinemaDbContext dbContext) => _dbContext = dbContext;

        public object GetAll() => _dbContext.Movies.ToList();
    }
}
