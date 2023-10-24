using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models;

public class TravelApiContext : DbContext
{
  public DbSet<Review> Reviews { get; set; }
  public DbSet<Destination> Destinations { get; set; }

  public TravelApiContext(DbContextOptions<TravelApiContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Destination>()
      .HasData(
        new Destination { DestinationId = 1, Landmark = "Portland Sign", City = "Portland, Oregon", Country = "United State" },
        new Destination { DestinationId = 2, Landmark = "Lake Champlain", City = "Burlington, Vermont", Country = "United State" },
        new Destination { DestinationId = 3, Landmark = "Big Sur", City = "Big Sur, California", Country = "United State" }
      );

    builder.Entity<Review>()
      .HasData(
        new Review { ReviewId = 1, Remarks = "It rains too much.", Rating = 6, DestinationId = 1 },
        new Review { ReviewId = 2, Remarks = "The trees are beautiful in the fall!", Rating = 10, DestinationId = 2 },
        new Review { ReviewId = 3, Remarks = "I've never seen a better sunset.", Rating = 9, DestinationId = 3 },
        new Review { ReviewId = 4, Remarks = "Some amazing food in this city!", Rating = 8, DestinationId = 1 },
        new Review { ReviewId = 5, Remarks = "The people don't understand sarcasm.", Rating = 7, DestinationId = 1 },
        new Review { ReviewId = 6, Remarks = "I'd raise a family here.", Rating = 9, DestinationId = 2 }
      );
  }
}