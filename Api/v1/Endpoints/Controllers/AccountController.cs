using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using APIX = SmartHousing.API.Database.Models;
using DAL = SmartHousing.API.Bal.Models;
using AutoMapper;
using SmartHousing.API.v1.Services;

namespace SmartHousing.API.v1.Endpoints.Controllers
{
  [Route("api/v1/[controller]")]
  public class AccountController : Controller
  {
    private readonly IAccountService _accountService;
    public AccountController(IAccountService accountService)
    {
      this._accountService = accountService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]DAL.User user)
    {
      return await _accountService.Login(user);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody]DAL.User user)
    {
      return await _accountService.Register(user);
    }
  }
}
