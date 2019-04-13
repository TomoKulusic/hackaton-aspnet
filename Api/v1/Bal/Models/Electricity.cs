using System;
using SmartHousing.API.Bal.Models.Enums;

namespace SmartHousing.API.Bal.Models
{
  public class Electricity
  {
    public int Id { get; set; }
    public double Amount { get; set; }
    public int TarriffId { get; set; }
  }
}
