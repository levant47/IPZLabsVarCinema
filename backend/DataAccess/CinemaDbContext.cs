using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace IPZLabsVarCinema
{
    public class CinemaDbContext : DbContext
    {
        public DbSet<Hall> Halls { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<MovieSchedule> MovieSchedules { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Schedule> Schedules { get; set; } = null!;
        public DbSet<Session> Sessions { get; set; } = null!;
        public DbSet<Shift> Shifts { get; set; } = null!;
        public DbSet<ShiftBarista> ShiftBaristas { get; set; } = null!;
        public DbSet<ShiftEngineer> ShiftEngineers { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<TicketProduct> TicketProducts { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=cinema.db");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite primary keys
            modelBuilder.Entity<MovieSchedule>()
                .HasKey(movieSchedule => new { movieSchedule.MovieId, movieSchedule.ScheduleId });

            modelBuilder.Entity<ShiftBarista>()
                .HasKey(shiftBarista => new { shiftBarista.ShiftId, shiftBarista.UserId });

            modelBuilder.Entity<ShiftEngineer>()
                .HasKey(shiftEngineer => new { shiftEngineer.ShiftId, shiftEngineer.UserId });

            modelBuilder.Entity<TicketProduct>()
                .HasKey(ticketProduct => new { ticketProduct.TicketId, ticketProduct.ProductId });

            // Foreign keys
            modelBuilder.Entity<MovieSchedule>()
                .HasOne<Movie>()
                .WithMany()
                .HasForeignKey(movieSchedule => movieSchedule.MovieId);
            modelBuilder.Entity<MovieSchedule>()
                .HasOne<Schedule>()
                .WithMany()
                .HasForeignKey(movieSchedule => movieSchedule.ScheduleId);
            modelBuilder.Entity<Session>()
                .HasOne(session => session.Movie)
                .WithMany()
                .HasForeignKey(session => session.MovieId);
            modelBuilder.Entity<Session>()
                .HasOne(session => session.Hall)
                .WithMany()
                .HasForeignKey(session => session.HallId);
            modelBuilder.Entity<ShiftBarista>()
                .HasOne<Shift>()
                .WithMany()
                .HasForeignKey(shiftBarista => shiftBarista.ShiftId);
            modelBuilder.Entity<ShiftBarista>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(shiftBarista => shiftBarista.UserId);
            modelBuilder.Entity<ShiftEngineer>()
                .HasOne<Shift>()
                .WithMany()
                .HasForeignKey(shiftEngineer => shiftEngineer.ShiftId);
            modelBuilder.Entity<ShiftEngineer>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(shiftEngineer => shiftEngineer.UserId);
            modelBuilder.Entity<Ticket>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(ticket => ticket.UserId);
            modelBuilder.Entity<Ticket>()
                .HasOne(ticket => ticket.Session)
                .WithMany(session => session.Tickets)
                .HasForeignKey(ticket => ticket.SessionId);
            modelBuilder.Entity<TicketProduct>()
                .HasOne<Ticket>()
                .WithMany()
                .HasForeignKey(ticketProduct => ticketProduct.TicketId);
            modelBuilder.Entity<TicketProduct>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(ticketProduct => ticketProduct.ProductId);
        }

        public void Seed()
        {
            var now = DateTime.Now;
            var random = new Random(Environment.TickCount);
            var RandomRating = new Func<float>(() =>
            {
                return (float)(random.NextDouble() * 4 + 1);
            });

            var movies = new[]
            {
                new Movie
                (
                    Id: 0,
                    Name: "Hero",
                    Year: 2002,
                    rating: RandomRating(),
                    Description:
@"Hero is a 2002 Chinese wuxia film directed by Zhang Yimou. Starring Jet Li as the nameless protagonist, the film is based on the story of Jing Ke's assassination attempt on the King of Qin in 227 BC.
Hero was first released in China on 24 October 2002. At that time, it was the most expensive project and one of highest-grossing motion pictures in China. Miramax acquired American market distribution rights, but delayed the release of the film for nearly two years. Quentin Tarantino eventually convinced Miramax to open the film in American theaters on 27 August 2004. The film received positive reviews from critics. It became the first Chinese-language movie to place No. 1 at the American box office, where it stayed for two consecutive weeks, and went on to earn $53.7 million in the United States and $177 million worldwide.",
                    Poster: "https://m.media-amazon.com/images/M/MV5BMWQ2MjQ0OTctMWE1OC00NjZjLTk3ZDAtNTk3NTZiYWMxYTlmXkEyXkFqcGdeQXVyMTQxNzMzNDI@._V1_UY1200_CR89,0,630,1200_AL_.jpg"
                ),
                new Movie
                (
                    Id: 0,
                    Name: "Ip Man 4",
                    Year: 2020,
                    rating: RandomRating(),
                    Description:
@"Ip Man 4: The Finale is a 2019 martial arts film directed by Wilson Yip and produced by Raymond Wong. It is the fourth and final film in the Ip Man film series, which is loosely based on the life of the Wing Chun grandmaster of the same name, and features Donnie Yen in the title role.
A co-production of Hong Kong and China, the film began production in April 2018 and ended in July of the same year. It was released on 20 December 2019.",
                    Poster: "https://m.media-amazon.com/images/M/MV5BNzYyZWIwZjQtZGVjZi00NWIxLTk0ODMtNzA3YzE5MWM3OWI0XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg"
                ),
                new Movie
                (
                    Id: 0,
                    Name: "Titanic",
                    Year: 1997,
                    rating: RandomRating(),
                    Description:
@"Titanic is a 1997 American epic romance and disaster film directed, written, co-produced, and co-edited by James Cameron. 
Incorporating both historical and fictionalized aspects, it is based on accounts of the sinking of the RMS Titanic, and stars Leonardo DiCaprio and Kate Winslet as members of different social classes who fall in love aboard the ship during its ill-fated maiden voyage.",
                    Poster: "https://cdn.shopify.com/s/files/1/1416/8662/products/titanic_1997_styleA_original_film_art_d26e81c0-1b87-4076-9da4-9fcdc0389ea5_1200x.jpg?v=1607475298"
                ),
                new Movie
                (
                    Id: 0,
                    Name: "The Wolf of Wall Street",
                    Year: 2013,
                    rating: RandomRating(),
                    Description:
@"The Wolf of Wall Street is a 2013 American epic biographical black comedy crime film directed by Martin Scorsese and written by Terence Winter, based on the 2007 memoir of the same name by Jordan Belfort. It recounts Belfort's perspective on his career as a stockbroker in New York City and how his firm, Stratton Oakmont, engaged in rampant corruption and fraud on Wall Street, which ultimately led to his downfall. 
Leonardo DiCaprio, who was also a producer on the film, stars as Belfort, with Jonah Hill as his business partner and friend, Donnie Azoff, Margot Robbie as his wife, Naomi Lapaglia, and Kyle Chandler as FBI agent Patrick Denham, who tries to bring Belfort down.",
                    Poster: "https://flxt.tmsimg.com/assets/p9991602_p_v13_af.jpg"
                ),
                new Movie
                (
                    Id: 0,
                    Name: "The Big Short",
                    Year: 2015,
                    rating: RandomRating(),
                    Description:
@"The Big Short is a 2015 American biographical comedy-drama film directed by Adam McKay. Written by McKay and Charles Randolph, it is based on the 2010 book The Big Short: Inside the Doomsday Machine by Michael Lewis showing how the financial crisis of 2007–2008 was triggered by the United States housing bubble. 
The film stars Christian Bale, Steve Carell, Ryan Gosling and Brad Pitt, with Melissa Leo, Hamish Linklater, John Magaro, Rafe Spall, Jeremy Strong, Finn Wittrock, and Marisa Tomei in supporting roles.",
                    Poster: "https://m.media-amazon.com/images/M/MV5BNDc4MThhN2EtZjMzNC00ZDJmLThiZTgtNThlY2UxZWMzNjdkXkEyXkFqcGdeQXVyNDk3NzU2MTQ@._V1_UY1200_CR69,0,630,1200_AL_.jpg"
                ),
                new Movie
                (
                    Id: 0,
                    Name: "Jobs",
                    Year: 2013,
                    rating: RandomRating(),
                    Description:
@"Jobs is a 2013 American biographical drama film based on the life of Steve Jobs, from 1974 while a student at Reed College to the introduction of the iPod in 2001. It is directed by Joshua Michael Stern, written by Matt Whiteley, and produced by Stern and Mark Hulme. Steve Jobs is portrayed by Ashton Kutcher, with Josh Gad as Apple Computer's co-founder Steve Wozniak. 
Jobs was chosen to close the 2013 Sundance Film Festival.",
                    Poster: "https://m.media-amazon.com/images/M/MV5BMTM5NTQ3MTYxN15BMl5BanBnXkFtZTcwODE2Nzk3OQ@@._V1_.jpg"
                ),
                new Movie
                (
                    Id: 0,
                    Name: "Murder on the Orient Express",
                    Year: 2017,
                    rating: RandomRating(),
                    Description:
@"Murder on the Orient Express is a 2017 American mystery thriller film directed by Kenneth Branagh with a screenplay by Michael Green, based on the 1934 novel of the same name by Agatha Christie. The film stars Branagh as Hercule Poirot, with Penélope Cruz, Willem Dafoe, Judi Dench, Johnny Depp, Josh Gad, Derek Jacobi, Leslie Odom Jr., Michelle Pfeiffer, and Daisy Ridley in supporting roles. 
The film is the fourth screen adaptation of Christie's novel, following the 1974 film, a 2001 TV film version, and a 2010 episode of the television series Agatha Christie's Poirot. The plot follows Poirot, a world-renowned detective, as he investigates a murder on the luxury Orient Express train service in the 1930s.",
                    Poster: "https://cdn11.bigcommerce.com/s-yshlhd/images/stencil/1280x1280/products/12377/162456/full.murderontheorientexpress_27655__09804.1556889989.jpg?c=2?imbypass=on"
                ),
                new Movie
                (
                    Id: 0,
                    Name: "Pulp Fiction",
                    Year: 1994,
                    rating: RandomRating(),
                    Description:
@"Pulp Fiction is a 1994 American neo-noir black comedy crime film written and directed by Quentin Tarantino, who conceived it with Roger Avary. Starring John Travolta, Samuel L. Jackson, Bruce Willis, Tim Roth, Ving Rhames, and Uma Thurman, it tells several stories of criminal Los Angeles. 
The title refers to the pulp magazines and hardboiled crime novels popular during the mid-20th century, known for their graphic violence and punchy dialogue.",
                    Poster: "https://prod.miramax.digital/media/assets/Pulp-Fiction1.png"
                ),
                new Movie
                (
                    Id: 0,
                    Name: "Home Alone 2: Lost in New York",
                    Year: 1992,
                    rating: RandomRating(),
                    Description:
@"Home Alone 2: Lost in New York is a 1992 American comedy film written and produced by John Hughes and directed by Chris Columbus. It is the second film in the Home Alone series and the sequel to the 1990 film Home Alone. 
The film stars Macaulay Culkin, Joe Pesci, Daniel Stern, John Heard, Tim Curry, Brenda Fricker and Catherine O'Hara. The film follows Kevin (Culkin), a 10-year-old boy, who once again must fend off two burglars, Harry and Marv (Pesci and Stern), after he is mistakenly separated from his family on their Christmas vacation.",
                    Poster: "https://flxt.tmsimg.com/assets/p14385_p_v10_af.jpg"
                ),
                new Movie
                (
                    Id: 0,
                    Name: "The Conjuring",
                    Year: 2013,
                    rating: RandomRating(),
                    Description:
@"The Conjuring is a 2013 American supernatural horror film directed by James Wan and written by Chad Hayes and Carey W. Hayes. It is the inaugural film in the Conjuring Universe franchise. Patrick Wilson and Vera Farmiga star as Ed and Lorraine Warren, paranormal investigators and authors associated with prominent cases of haunting. Their purportedly real-life reports inspired The Amityville Horror story and film franchise. 
The Warrens come to the assistance of the Perron family, who experienced increasingly disturbing events in their farmhouse in Rhode Island in 1971.",
                    Poster: "https://images.moviesanywhere.com/64428a3af2258a8186ca97896f1fb060/de21bfe7-e298-4210-bdef-bfac8b2c53d0.jpg"
                ),
                new Movie
                (
                    Id: 0,
                    Name: "Saving Private Ryan",
                    Year: 1998,
                    rating: RandomRating(),
                    Description:
@"Saving Private Ryan is a 1998 American epic war film directed by Steven Spielberg and written by Robert Rodat. Set during the Invasion of Normandy in World War II, the film is known for its graphic portrayal of war, especially its depiction of the Omaha Beach assault during the Normandy landings. 
The film follows United States Army Rangers Captain John H. Miller (Tom Hanks) and his squad (Tom Sizemore, Edward Burns, Barry Pepper, Giovanni Ribisi, Vin Diesel, Adam Goldberg, and Jeremy Davies) as they search for a paratrooper, Private First Class James Francis Ryan (Matt Damon), the last surviving brother of four, the three other brothers having been killed in action. The film was a co-production between DreamWorks Pictures, Paramount Pictures, Amblin Entertainment, and Mutual Film Company. DreamWorks distributed the film in North America while Paramount released the film internationally.",
                    Poster: "https://resizing.flixster.com/_UOtw8eSWN5-FjJe_mN6v41y1bI=/ems.ZW1zLXByZC1hc3NldHMvbW92aWVzLzc1MDczNGJlLWNjN2EtNGIxMS1iOWM5LWJjYTUwODk4MzA5Yy53ZWJw"
                ),
                new Movie
                (
                    Id: 0,
                    Name: "Harry Potter and the Philosopher's Stone",
                    Year: 2001,
                    rating: RandomRating(),
                    Description:
@"Harry Potter and the Philosopher's Stone is a fantasy novel written by British author J. K. Rowling. The first novel in the Harry Potter series and Rowling's debut novel, it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh birthday, when he receives a letter of acceptance to Hogwarts School of Witchcraft and Wizardry. 
Harry makes close friends and a few enemies during his first year at the school, and with the help of his friends, he faces an attempted comeback by the dark wizard Lord Voldemort, who killed Harry's parents, but failed to kill Harry when he was just 15 months old.",
                    Poster: "https://fadutown.com/wp-content/uploads/2020/08/81YOuOGFCJL.jpg"
                ),
            };
            Movies.AddRange(movies.Reverse());

            var defaultSeatRowCount = 10;
            var defaultRowSize = 15;
            var halls = new[]
            {
                new Hall
                (
                    Id: 0,
                    Name: "Hall A",
                    SeatRowCount: defaultSeatRowCount,
                    SeatRowSize: defaultRowSize
                ),
                new Hall
                (
                    Id: 0,
                    Name: "Hall B",
                    SeatRowCount: defaultSeatRowCount,
                    SeatRowSize: defaultRowSize
                ),
                new Hall
                (
                    Id: 0,
                    Name: "Hall C",
                    SeatRowCount: defaultSeatRowCount,
                    SeatRowSize: defaultRowSize
                ),
                new Hall
                (
                    Id: 0,
                    Name: "Hall D",
                    SeatRowCount: defaultSeatRowCount,
                    SeatRowSize: defaultRowSize
                ),
                new Hall
                (
                    Id: 0,
                    Name: "Hall E",
                    SeatRowCount: defaultSeatRowCount,
                    SeatRowSize: defaultRowSize
                ),
                new Hall
                (
                    Id: 0,
                    Name: "Hall F",
                    SeatRowCount: defaultSeatRowCount,
                    SeatRowSize: defaultRowSize
                ),
            };
            Halls.AddRange(halls);

            var users = new[]
            {
                new User
                (
                    Id: 0,
                    FirstName: "Anton",
                    LastName: "Bodiak",
                    Email: "anton.bodiak@nure.ua",
                    RegistrationTime: now,
                    Password: PasswordEncoder.Encode("test"),
                    Role: Role.Client
                ),
                new User
                (
                    Id: 0,
                    FirstName: "Oleg",
                    LastName: "Kurchenko",
                    Email: "oleg.kurchenko@nure.ua",
                    RegistrationTime: now,
                    Password: PasswordEncoder.Encode("test"),
                    Role: Role.Client
                ),
            };
            Users.AddRange(users);

            SaveChanges();

            var sessionTimes = new []
            {
                new DateTime(now.Year, now.Month, now.Day + 1, 12, 0, 0),
                new DateTime(now.Year, now.Month, now.Day + 1, 14, 0, 0),
                new DateTime(now.Year, now.Month, now.Day + 1, 16, 0, 0),
                new DateTime(now.Year, now.Month, now.Day + 1, 18, 0, 0),
                new DateTime(now.Year, now.Month, now.Day + 1, 20, 0, 0),
            };
            var sessions = sessionTimes.SelectMany(sessionTime => movies.Select(movie => new Session
            (
                Id: 0,
                MovieId: movie.Id,
                HallId: halls.GetRandomElement().Id,
                StartTime: sessionTime
            ))).ToList();
            Sessions.AddRange(sessions);

            SaveChanges();
        }
    }
}
