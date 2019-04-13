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
using SmartHousing.API.Database.Models;

namespace SmartHousing.API.v1.Services
{
  public interface IWaterService
  {
     API.Bal.Models.Water Post(Water water);
  }

  public class WaterService : IWaterService
  {
    private readonly SmartHousingContext _context;
    private readonly IMapper _mapper;

    public WaterService(SmartHousingContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }


    public  API.Bal.Models.Water Post(Water water)
    {
      using (var trasnaction = _context.Database.BeginTransaction())
      {
        var newWater = this._mapper.Map<API.Bal.Models.Water>(water);
        this._context.Water.Add(newWater);
        this._context.SaveChanges();
        trasnaction.Commit();
        return newWater;
      }
    }
  }
}
