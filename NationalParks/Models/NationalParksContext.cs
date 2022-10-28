using Microsoft.EntityFrameworkCore;

namespace NationalParks.Models
{
    public class NationalParksContext : DbContext
    {
        public NationalParksContext(DbContextOptions<NationalParksContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
          builder.Entity<Service>()
            .HasData(
              new Service { ServiceId = 1, Name = "Glacier National Park Lodges", Type = "Lodging", Description = "Our guest experience is characterized by warm, personalized service and convenient in-room amenities to make the most of your stay in Glacier National Park.", Cost = 100, ParkId = 1}
            );
          builder.Entity<Park>()
            .HasData(
              new Park { ParkId = 1, Name = "Glacier National Park", State = "Montana", Country = "USA", Cost = 35}
            );
        }
        public DbSet<Park> Parks { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}