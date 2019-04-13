using System;
using SmartHousing.API.Bal.Models.Enums;

namespace SmartHousing.API.Bal.Models
{
  public class Utilities
  {
    public int Id { get; set; }
    public int Entry_id { get; set; } // foregin key for Water / Electricity Id

    public DateTime Date { get; set; }
    public Double Amount { get; set; }
    public UtilityType UtilityType { get; set; }
    // public int User_id { get; set; }
  }
}
