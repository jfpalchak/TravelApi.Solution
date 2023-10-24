using System.Text.Json.Serialization;

namespace TravelApi.Models;

public class Destination 
{
  public int DestinationId { get; set; }
  public string Landmark { get; set; }
  public string City { get; set; }
  public string Country { get; set; }

  public double AverageRating { get; set; }

  [JsonIgnore]
  public List<Review> Reviews { get; set; }
}