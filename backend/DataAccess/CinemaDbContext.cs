using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Logging;
using System;

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
                .HasOne<Movie>()
                .WithMany()
                .HasForeignKey(session => session.MovieId);
            modelBuilder.Entity<Session>()
                .HasOne<Hall>()
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
                .HasOne<Session>()
                .WithMany()
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
            Movies.AddRange(
                new Movie
                (
                    Id: 0,
                    Name: "Hero",
                    Year: 2002,
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
                    Description:
@"Ip Man 4: The Finale is a 2019 martial arts film directed by Wilson Yip and produced by Raymond Wong. It is the fourth and final film in the Ip Man film series, which is loosely based on the life of the Wing Chun grandmaster of the same name, and features Donnie Yen in the title role.
A co-production of Hong Kong and China, the film began production in April 2018 and ended in July of the same year. It was released on 20 December 2019.",
                    Poster: "https://m.media-amazon.com/images/M/MV5BNzYyZWIwZjQtZGVjZi00NWIxLTk0ODMtNzA3YzE5MWM3OWI0XkEyXkFqcGdeQXVyMTMxODk2OTU@._V1_.jpg"
                )
            );
        }
    }
}
