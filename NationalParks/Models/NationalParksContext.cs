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
              new Service { ServiceId = 1, Name = "Glacier National Park Lodges", Type = "Lodging", Description = "Multiple lodges to choose from", Cost = 100, ParkId = 1},
              new Service { ServiceId = 2, Name = "Guided Tours", Type = "Tours", Description = "Boat, bus, raft and horseback tours available", Cost = 80, ParkId = 1},
              new Service { ServiceId = 3, Name = "Wilderness Camping", Type = "Camping", Description = "First come first serve, with overnight parking ", Cost = 40, ParkId = 1},
              new Service { ServiceId = 4, Name = "Yosemite Lodging", Type = "Lodging", Description = "Tent cabins at  High Sierra Camps / deluxe rooms at The Ahwahnee", Cost = 120, ParkId = 2},
              new Service { ServiceId = 5, Name = "Ranger & Interpretive Programs", Type = "Program", Description = "Ranger-led programs may be available on a limited basis", Cost = 40, ParkId = 2},
              new Service { ServiceId = 6, Name = "South Rim Lodgine", Type = "Lodging", Description = "South Rim lodging is available all year", Cost = 90, ParkId = 3},
              new Service { ServiceId = 7, Name = "Desert View", Type = "Scenery", Description = "23 mile scenic road between Desert View and Grand Canyon Village,", Cost = 0, ParkId = 3},
              new Service { ServiceId = 8, Name = "Grand Canyon Vistor Center", Type = "Amenities", Description = "coffee bar, grab-and-go breakfast and Lunch, and hiker/biker supplies", Cost = 0, ParkId = 3},
              new Service { ServiceId = 9, Name = "Yosemite Campgrounds", Type = "Camping", Description = "12 campgrounds with over 2,000 established campsites.", Cost = 30, ParkId = 4},
              new Service { ServiceId = 10, Name = "Miette Hot Springs", Type = "Scenery", Description = "Hottest hot springs in the Canadian Rockies", Cost = 0, ParkId = 5},
              new Service { ServiceId = 11, Name = "Wildlife Tours", Type = "Tours", Description = "See elk, deer, bear, moose and mountain goats ", Cost = 140, ParkId = 5}
            );
          builder.Entity<Park>()
            .HasData(
              new Park { ParkId = 1, Name = "Glacier National Park", State = "Montana", Country = "USA", Cost = 35},
              new Park { ParkId = 2, Name = "Yosemite National Park", State = "California", Country = "USA", Cost = 35},
              new Park { ParkId = 3, Name = "Grand Canyon National Park", State = "Arizona", Country = "USA", Cost = 35},
              new Park { ParkId = 4, Name = "Yellowstone National Park", State = "Wyoming", Country = "USA", Cost = 20},
              new Park { ParkId = 5, Name = "Jasper National Park", State = "Alberta", Country = "Canada", Cost = 10}
            );
        }
        public DbSet<Park> Parks { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}