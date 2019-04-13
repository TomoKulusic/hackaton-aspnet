using System;
using SmartHousing.API.Bal.Models.Enums;

namespace SmartHousing.API.Bal.Models
{
  public class WaterTariff
  {
    public int Id { get; set; }
    public string  Name { get; set; }
    public double Tariff { get; set; }
  }
}
