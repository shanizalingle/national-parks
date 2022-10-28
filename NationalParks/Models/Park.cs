using System.Collections.Generic;
namespace NationalParks.Models
{
  public class Park
  {
    public Park()
    {
      this.Services = new HashSet<Service>();
    }
    public int ParkId { get; set; }
    public string Name { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public int Cost { get; set; }
    public ICollection<Service> Services { get; set; }
  }
}