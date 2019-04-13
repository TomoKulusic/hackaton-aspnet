using System;
using SmartHousing.API.Bal.Models.Enums;

namespace SmartHousing.API.Bal.Models
{
  public class Electricity_Tariff
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public double One_Tarrif { get; set; } 
    public double High_Tarrif { get; set; }
    public double Low_Tarrif { get; set; }
    public double Supply_Fee { get; set; }
  }
}
