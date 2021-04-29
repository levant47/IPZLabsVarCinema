using System;
using System.Threading.Tasks;

namespace IPZLabsVarCinema
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using var dbContext = new CinemaDbContext();
            dbContext.Database.EnsureCreated();
            Console.WriteLine("Success!");
        }
    }
}
