using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IPZLabsVarCinema
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using var dbContext = new CinemaDbContext();
            dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            dbContext.Add(new User
            (
                Id: 0,
                FirstName: "Joe",
                LastName: "Biden",
                Email: "joe_biden@cinema.com",
                RegistrationTime: DateTime.Now,
                Password: PasswordEncoder.Encode("america123"),
                Role: Role.Administrator
            ));
            await dbContext.SaveChangesAsync();

            var dict = new Dictionary<int, int> { { 1, 1 }, { 2, 2 } };
            Console.WriteLine(string.Join(", ", (await dbContext.Users.Where(user => dict.ContainsValue(user.Id)).ToListAsync()).Select(user => user.ToString())));
        }
    }
}
