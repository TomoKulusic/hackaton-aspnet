using System;
using SmartHousing.API.Bal.Models.Enums;

namespace SmartHousing.API.Bal.Models
{
  public class Water
  {
    public int Id { get; set; }
    public double Amount { get; set; }
    public int Tarriff_id { get; set; }


  }
}