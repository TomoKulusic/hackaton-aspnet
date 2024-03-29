using System;
using SmartHousing.API.Bal.Models;

namespace SmartHousing.API.Bal.Models
{
  public class ElectricityTariff
  {
    public int Id { get; set; }
    public ElectricityTariffEnum ElectricityTariffEnum { get; set; }
    public double? OneTarrif { get; set; } 
    public double? HighTarrif { get; set; }
    public double? LowTarrif { get; set; }
    public double SupplyFee { get; set; }
  }
}
