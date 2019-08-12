using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SmartHousing.API.Bal.Models
{
  public class UserRole : IdentityUserRole<int>
  {
    public int Id { get; set; }
  }
}
