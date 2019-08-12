using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using APIX = SmartHousing.API.Database.Models;
using DAL = SmartHousing.API.Bal.Models;

namespace SmartHousing.API.v1.Services
{
  public class Service
  {
    public readonly RoleManager<DAL.Role> _roleManager;
    public readonly UserManager<DAL.User> _userManager;
    public readonly IHttpContextAccessor _httpContextAccessor;

    public Service(
      RoleManager<DAL.Role> roleManager,
      UserManager<DAL.User> userManager,
      IHttpContextAccessor httpContextAccessor)
    {
      _roleManager = roleManager;
      _userManager = userManager;
      _httpContextAccessor = httpContextAccessor;
    }
    public int CurrentUserId()
    {
      var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
      return int.Parse(userId);
    }
  }
}
