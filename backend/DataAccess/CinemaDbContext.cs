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
    }
}
