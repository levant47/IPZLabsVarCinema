using System;
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
            var usersRepository = new UsersRepository(dbContext);

            var newUser = new User
            (
                Id: 0,
                FirstName: "Joe",
                LastName: "Biden",
                Email: "joe_biden@cinema.com",
                RegistrationTime: DateTime.Now,
                Password: PasswordEncoder.Encode("america123"),
                Role: Role.Administrator
            );
            var createdUser = usersRepository.Create(newUser);
            var fetchedUser = usersRepository.GetById(createdUser.Id);
            Console.WriteLine(string.Join("\n",
                $"Created user: {createdUser}",
                $"Fetched user: {fetchedUser}"
            ));
        }
    }
}
