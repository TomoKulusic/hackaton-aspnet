using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SmartHousing.API.Bal.Models
{
  public class User : IdentityUser<int>
  {
    [NotMapped]
    public string Password { get; set; }

  }
}
