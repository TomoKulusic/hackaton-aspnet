using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

using Proteron.HumanitarianAid.DAL;

using AutoMapper;
using SmartHousing.API.Database.Context;

namespace SmartHousing.API.v1.Services
{
  public interface IElectricityService
  {
    IActionResult Get();
  }

  public class ElectricityService : IElectricityService
  {
    private readonly SmartHousingContext _context;
    private readonly IMapper _mapper;

    public ElectricityService(SmartHousingContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public IActionResult Get()
    {
      return null;
    }



  }
}
