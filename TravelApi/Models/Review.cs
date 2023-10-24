using System.Text.Json.Serialization;

namespace TravelApi.Models;

public class Review 
{
  public int ReviewId { get; set; }
  public string Remarks { get; set; }
  public int Rating { get; set; }
  
  [JsonIgnore]
  public int DestinationId { get; set; }
  public Destination Destination { get; set; }
}