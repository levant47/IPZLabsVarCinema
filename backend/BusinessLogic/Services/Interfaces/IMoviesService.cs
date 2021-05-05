using System.Collections.Generic;

namespace IPZLabsVarCinema
{
    public interface IMoviesServices
    {
        List<MovieDto> GetCurrent();

        MovieDto GetById();
    }
}
