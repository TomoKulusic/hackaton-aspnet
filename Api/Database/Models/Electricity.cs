using System;
using SmartHousing.API.Bal.Models.Enums;

namespace SmartHousing.API.Database.Models
{
  public class Electricity
  {
    public double Amount { get; set; }
    public int TarriffId { get; set; }
  }
}
