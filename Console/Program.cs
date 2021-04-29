using System;
using System.Threading.Tasks;

namespace IPZLabsVarCinema
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using var dbContext = new CinemaDbContext();

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            var now = DateTime.Now;

            var hall = dbContext.Halls.Add(new Hall
            (
                Id: 0,
                Name: "Hall 1",
                SeatRowCount: 20,
                SeatRowSize: 20
            )).Entity;
            var movie = dbContext.Movies.Add(new Movie
            (
                Id: 0,
                Name: "Mortal Kombat",
                Year: 2021,
                Description: "Mortal Kombat is a 2021 American martial arts fantasy film directed by Simon McQuoid",
                Poster: "data:image/png;base64,..."
            )).Entity;
            var product = dbContext.Products.Add(new Product
            (
                Id: 0,
                Name: "Popcorn",
                Price: 10m
            )).Entity;
            var schedule = dbContext.Schedules.Add(new Schedule
            (
                Id: 0,
                Year: now.Year,
                Week: now.Week()
            )).Entity;
            var shift = dbContext.Shifts.Add(new Shift
            (
                Id: 0,
                StartTime: new DateTime(2021, 04, 29, 16, 0, 0),
                Duration: new TimeSpan(8, 0, 0)
            )).Entity;
            var baristaUser = dbContext.Users.Add(new User
            (
                Id: 0,
                FirstName: "John",
                LastName: "Doe",
                Email: "john_doe@cinema.com",
                RegistrationTime: now,
                Password: PasswordEncoder.Encode("password123"),
                Role: Role.Personel
            )).Entity;
            var engineerUser = dbContext.Users.Add(new User
            (
                Id: 0,
                FirstName: "Jane",
                LastName: "Doe",
                Email: "jane_doe@cinema.com",
                RegistrationTime: now,
                Password: PasswordEncoder.Encode("password321"),
                Role: Role.Personel
            )).Entity;
            var clientUser = dbContext.Users.Add(new User
            (
                Id: 0,
                FirstName: "Will",
                LastName: "Smith",
                Email: "will_smith@gmail.com",
                RegistrationTime: now,
                Password: PasswordEncoder.Encode("password132"),
                Role: Role.Client
            )).Entity;

            var movieSchedule = dbContext.MovieSchedules.Add(new MovieSchedule
            (
                ScheduleId: schedule.Id,
                MovieId: movie.Id
            )).Entity;
            var session = dbContext.Sessions.Add(new Session
            (
                Id: 0,
                MovieId: movie.Id,
                HallId: hall.Id,
                StartTime: new DateTime(2021, 04, 29, 16, 0, 0)
            )).Entity;
            var shiftBarista = dbContext.ShiftBaristas.Add(new ShiftBarista
            (
                ShiftId: shift.Id,
                UserId: baristaUser.Id
            )).Entity;
            var shiftEngineer = dbContext.ShiftEngineers.Add(new ShiftEngineer
            (
                ShiftId: shift.Id,
                UserId: engineerUser.Id
            )).Entity;
            var ticket = dbContext.Tickets.Add(new Ticket
            (
                Id: 0,
                UserId: clientUser.Id,
                SessionId: session.Id,
                SeatRow: 10,
                SeatIndex: 8,
                PurchaseTime: now
            )).Entity;
            var ticketProduct = dbContext.TicketProducts.Add(new TicketProduct
            (
                TicketId: ticket.Id,
                ProductId: product.Id
            )).Entity;

            await dbContext.SaveChangesAsync();

            Console.WriteLine(string.Join("\n\n",
                $"==== Hall ====\n{hall}",
                $"==== Movie ====\n{movie}",
                $"==== Product ====\n{product}",
                $"==== Schedule ====\n{schedule}",
                $"==== Shift ====\n{shift}",
                $"==== Barista User ====\n{baristaUser}",
                $"==== Engineer User ====\n{engineerUser}",
                $"==== Client User ====\n{clientUser}",
                $"==== Movie Schedule ====\n{movieSchedule}",
                $"==== Session ====\n{session}",
                $"==== Shift Barista ====\n{shiftBarista}",
                $"==== Shift Engineer ====\n{shiftEngineer}",
                $"==== Ticket ====\n{ticket}",
                $"==== Ticket Product ====\n{ticketProduct}"
            ));
        }
    }
}
