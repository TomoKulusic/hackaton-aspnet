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



using AutoMapper;
using SmartHousing.API.Database.Context;
using SmartHousing.API.Database.Models;
using APIX = SmartHousing.API.Database.Models;
using DAL = SmartHousing.API.Bal.Models;
namespace SmartHousing.API.v1.Services
{
  public interface IElectricityService
  {
    DAL.Electricity Post(APIX.Electricity electricity);
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

    public DAL.Electricity Post(Electricity electricity)
    {
      using (var trasnaction = _context.Database.BeginTransaction())
      {
        var newElectricity = this._mapper.Map<DAL.Electricity>(electricity);
        this._context.Electricity.Add(newElectricity);
        this._context.SaveChanges();
        trasnaction.Commit();
        return newElectricity;
      }
    }
  }
}
