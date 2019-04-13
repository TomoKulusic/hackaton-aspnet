using System;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

using SmartHousing.API.ResponseWrapper;
using APIX = SmartHousing.API.Database.Models;
using DAL = SmartHousing.API.Bal.Models;

using AutoMapper;
using System.Net;
using SmartHousing.API.Database.Context;
using SmartHousing.Options;

namespace SmartHousing.API.v1.Services
{
  public interface IAccountService
  {
    Task<IActionResult> Login(DAL.User user);
    Task<IActionResult> Register(DAL.User user);
    
  }

  public class AccountService : IAccountService
  {
    const string AuthenticationType = "BearerJwtToken";
    private readonly SmartHousingContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<DAL.User> _userManager;
    private readonly IOptionsSnapshot<JwtIssuerOptions> _jwtIssuerOptions;
    private readonly IMapper _mapper;

    public AccountService(
      SmartHousingContext context,
      IHttpContextAccessor httpContextAccessor,
      UserManager<DAL.User> userManager,
      IOptionsSnapshot<JwtIssuerOptions> jwtIssuerOptions,
      IMapper mapper)
    {
      _context = context;
      _httpContextAccessor = httpContextAccessor;
      _userManager = userManager;
      _jwtIssuerOptions = jwtIssuerOptions;
      _mapper = mapper;
    }

    public async Task<IActionResult> Login(DAL.User user)
    {
      var result = await ValidateLoginAsync(user);
      if (result.valid)
      {
        var dalUser = _context.Users.FirstOrDefault(m => m.Email == user.Email);
        var response = new ApiResponse<APIX.User>(new APIX.User()
        {
          Id = dalUser.Id,
          Email = user.Email,
          Token = await GenerateJwtToken(dalUser)
        });
        return new OkObjectResult(response);
      }
      return new BadRequestObjectResult(result);
    }

    public async Task<IActionResult> Register(DAL.User user)
    {
      using (var transaction = _context.Database.BeginTransaction())
      {
        var dalUser = new DAL.User()
        {
          Email = user.Email,
          UserName = user.Email
        };
        var createResult = await _userManager.CreateAsync(dalUser, user.Password);
        var roleResult = await _userManager.AddToRoleAsync(dalUser, "user");

        if (createResult.Succeeded && roleResult.Succeeded)
        {
          
          transaction.Commit();
          var response = new ApiResponse<APIX.User>(new APIX.User()
          {
            Email = dalUser.Email
          });

          return new OkObjectResult(response);
        }
        else
        {
          return new BadRequestResult();
        }
      }
    }

    public async Task<IActionResult> RegisterConfirmationAsync(int id, string token)
    {
      var decodedToken = Uri.UnescapeDataString(token);
      var user = _context.Users.Where(m => m.Id == id).FirstOrDefault();
      if (user == null)
      {
        return new NotFoundResult();
      }
      else
      {
        var result = await _userManager.ConfirmEmailAsync(user, decodedToken);
        if (result.Succeeded)
        {
          return new OkResult();
        }
        else
        {
          return new NotFoundResult();
        }
      }
    }

    private async Task<ApiLoginResponse> ValidateLoginAsync(DAL.User user)
    {
      var dalUser = _context.Users.Where(m => m.Email == user.Email).FirstOrDefault();

      if (dalUser != null)
      {
        var validPassword = await this._userManager.CheckPasswordAsync(dalUser, user.Password);
        var isLockedOut = await this._userManager.IsLockedOutAsync(dalUser);
        var isConfirmed = dalUser.EmailConfirmed;
        if (!validPassword)
        {
          return new ApiLoginResponse(false, "Invalid password");
        }
        else if (isLockedOut)
        {
          return new ApiLoginResponse(false, "User locked out until " + dalUser.LockoutEnd);
        }
        else if (!isConfirmed)
        {
          return new ApiLoginResponse(false, "Email not confirmed");
        }
        else
        {
          return new ApiLoginResponse(true, null);
        }
      }
      return new ApiLoginResponse(false, "User not found");
    }

    public async Task<string> GenerateJwtToken(DAL.User user)
    {
      var claims = new ClaimsIdentity();
      var roles = await _userManager.GetRolesAsync(user);

      var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));
      claims.AddClaims(roleClaims);
      claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
      claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));

      var tokenHandler = new JwtSecurityTokenHandler();
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = claims,
        Expires = DateTime.UtcNow.Add(_jwtIssuerOptions.Value.ValidFor),
        SigningCredentials = _jwtIssuerOptions.Value.SigningCredentials
      };
      var securityToken = tokenHandler.CreateToken(tokenDescriptor);
      var token = tokenHandler.WriteToken(securityToken);
      return token;
    }

    
  }
}
