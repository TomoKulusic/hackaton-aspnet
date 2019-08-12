using System;
using SmartHousing.API.Bal.Models;

namespace SmartHousing.API.Bal.Models
{
  public class WaterTariff
  {
    public int Id { get; set; }
    public WaterTariffEnum  WaterTariffEnum { get; set; }
    public double Tariff { get; set; }
  }
}
