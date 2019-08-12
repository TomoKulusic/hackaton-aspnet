using System;
using SmartHousing.API.Bal.Models;

namespace SmartHousing.API.Database.Models
{
  public class Water
  {
    public int Id { get; set; }
    public double Amount { get; set; }
    public int TarriffId { get; set; }
  }
}
