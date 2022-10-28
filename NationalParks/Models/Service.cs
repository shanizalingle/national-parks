using System.Text.Json.Serialization;
namespace NationalParks.Models
{
  public class Service
  {
    public int ServiceId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
    [JsonIgnore]
    public virtual Park Park { get; set; }
  }
}