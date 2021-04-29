using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

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
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieSchedule>()
                .HasKey(movieSchedule => new { movieSchedule.MovieId, movieSchedule.ScheduleId });

            modelBuilder.Entity<ShiftBarista>()
                .HasKey(shiftBarista => new { shiftBarista.ShiftId, shiftBarista.UserId });

            modelBuilder.Entity<ShiftEngineer>()
                .HasKey(shiftEngineer => new { shiftEngineer.ShiftId, shiftEngineer.UserId });

            modelBuilder.Entity<TicketProduct>()
                .HasKey(ticketProduct => new { ticketProduct.TicketId, ticketProduct.ProductId });
        }
    }
}
