using System;
using System.ComponentModel.DataAnnotations;
using SmartHousing.API.Bal.Models;

namespace SmartHousing.API.Database.Models
{
  public class Utility
  {
    [Key]
    public int Id { get; set; }
    public int? WaterId { get; set; } // foregin key for Water / Electricity Id
    public Water Water { get; set; }
    public int? ElectricityId { get; set; }
    public Electricity Electricity { get; set; }
    public DateTime Date { get; set; }
    public Double Amount { get; set; }
    public SmartHouseCityRegion SmartHouseCityRegion { get; set; }
    public UtilityType UtilityType { get; set; }
    public int UserId { get; set; }
  }
}
