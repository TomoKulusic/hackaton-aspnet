using System;
using System.Collections.Generic;
using SmartHousing.API.Bal.Models;

namespace SmartHousing.API.Database.Models
{
  public class MonthUtilityResponse
  {
    public IEnumerable<int> Months;
    public IEnumerable<Water> Water;
    public IEnumerable<Electricity> Electricity;
  }
}
