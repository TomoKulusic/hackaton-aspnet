﻿namespace SmartHousing.API.Database.Models
{
  public class User
  {
    public int Id { get; set; }
    public string Token { get; set; }
    public string Email { get; set; }
    public string Name { get; set;}
    public string LastName { get; set; } 

  }
}
