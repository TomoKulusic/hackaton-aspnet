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
using SmartHousing.API.Bal.Models;
using APIX = SmartHousing.API.Database.Models;
using DAL = SmartHousing.API.Bal.Models;

namespace SmartHousing.API.v1.Services
{
  public interface IUtilitesService
  {
    IActionResult GetUtilitiesForCurrentMonthElectricity();
    IActionResult GetUtilitiesForCurrentMonthWater();
    IActionResult GetWaterUtilities();
    IActionResult GetElectricityUtilities();

    IActionResult GenerateWaterUtility(Water water);
    IActionResult GenerateElectricityUtility(Electricity electricity);

    IActionResult GetWaterByMonth(int month);
    IActionResult GetElectricityByMonth(int month);

  }

  public class UtilitesService : Service, IUtilitesService
  {
    private readonly SmartHousingContext _context;
    private readonly IMapper _mapper;
    private readonly AmountCalculator _amountCalculator;


    public UtilitesService(SmartHousingContext context,
     IMapper mapper,
      AmountCalculator amountCalculator,
      RoleManager<DAL.Role> roleManager,
      UserManager<DAL.User> userManager,
      IHttpContextAccessor httpContextAccessor) : base(roleManager, userManager, httpContextAccessor)
    {
      this._context = context;
      this._mapper = mapper;

      this._amountCalculator = amountCalculator;
    }

    public IActionResult GenerateElectricityUtility(Electricity electricity)
    {
      using (var trasnaction = _context.Database.BeginTransaction())
      {
        var currentDate = DateTime.Now;
        var utilities = this._context.Utilities
        .Where(m => m.UtilityType == UtilityType.Electricity && (m.Date.Day == currentDate.Day && m.Date.Month == currentDate.Month && m.Date.Year == currentDate.Year)).FirstOrDefault();

        if (utilities == null)
        {
          var utility = new Utility
          {
            ElectricityId = electricity.Id,
            Date = DateTime.Now,
            Amount = this._amountCalculator.getElectricityTariff(electricity.TarriffId, electricity.Amount),
            UtilityType = UtilityType.Electricity
          };
          this._context.Utilities.Add(utility);
          this._context.SaveChanges();
          trasnaction.Commit();
          return new OkObjectResult(utility);

        }
        else
        {
          utilities.Amount += this._amountCalculator.getElectricityTariff(electricity.TarriffId, electricity.Amount);
          utilities.Date = currentDate;
        }
        this._context.SaveChanges();
        trasnaction.Commit();
        return new OkObjectResult(utilities);
      }
    }

    public IActionResult GenerateWaterUtility(Water water)
    {
      using (var trasnaction = _context.Database.BeginTransaction())
      {
        var currentDate = DateTime.Now;
        var utilities = this._context.Utilities
        .Where(m => m.UtilityType == UtilityType.Water && (m.Date.Day == currentDate.Day && m.Date.Month == currentDate.Month && m.Date.Year == currentDate.Year)).FirstOrDefault();

        if (utilities == null)
        {

          var utility = new Utility
          {
            WaterId = water.Id,
            Date = DateTime.Now,
            Amount = this._amountCalculator.getWaterTariff(water.TarriffId, water.Amount),
            UtilityType = UtilityType.Water,
            SmartHouseCityRegion = SmartHouseCityRegion.Lapad
          };
          this._context.Utilities.Add(utility);
          this._context.SaveChanges();
          trasnaction.Commit();
          return new OkObjectResult(utility);

        }
        else
        {
          utilities.Amount += this._amountCalculator.getWaterTariff(water.TarriffId, water.Amount);
          utilities.Date = currentDate;
        }
        this._context.SaveChanges();
        trasnaction.Commit();
        return new OkObjectResult(utilities);
      }
    }

    public IActionResult GetElectricityByMonth(int month)
    {
      var utilities = this._context.Utilities
            .Where(m => m.UtilityType == UtilityType.Electricity && m.Date.Month == month).ToList();

      var mappedApplications = this._mapper.Map<IEnumerable<Utility>>(utilities);
      var paginatedResponse = new ApiPaginatedResponse<IEnumerable<Utility>>(mappedApplications, utilities.Count());

      return new OkObjectResult(paginatedResponse);
    }

    public IActionResult GetElectricityUtilities()
    {
      var currentDate = DateTime.Now;
      var utilities = this._context.Utilities
      .Where(m => m.UtilityType == UtilityType.Electricity).ToList();

      var mappedApplications = this._mapper.Map<IEnumerable<Utility>>(utilities);
      var paginatedResponse = new ApiPaginatedResponse<IEnumerable<Utility>>(mappedApplications, utilities.Count());

      return new OkObjectResult(paginatedResponse);
    }

    public IActionResult GetUtilitiesForCurrentMonthElectricity()
    {
      var currentDate = DateTime.Now;
      var utilities = this._context.Utilities
      .Where(m => m.UtilityType == UtilityType.Electricity && m.Date.Month == currentDate.Month).ToList();

      var mappedApplications = this._mapper.Map<IEnumerable<Utility>>(utilities);
      var paginatedResponse = new ApiPaginatedResponse<IEnumerable<Utility>>(mappedApplications, utilities.Count());

      return new OkObjectResult(paginatedResponse);
    }

    public IActionResult GetUtilitiesForCurrentMonthWater()
    {
      var currentDate = DateTime.Now;
      var utilities = this._context.Utilities
      .Where(m => m.UtilityType == UtilityType.Water && m.Date.Month == currentDate.Month).ToList();

      var mappedApplications = this._mapper.Map<IEnumerable<Utility>>(utilities);
      var paginatedResponse = new ApiPaginatedResponse<IEnumerable<Utility>>(mappedApplications, utilities.Count());

      return new OkObjectResult(paginatedResponse);
    }

    public IActionResult GetWaterByMonth(int month)
    {
      var utilities = this._context.Utilities
      .Where(m => m.UtilityType == UtilityType.Water && m.Date.Month == month).ToList();

      var mappedApplications = this._mapper.Map<IEnumerable<Utility>>(utilities);
      var paginatedResponse = new ApiPaginatedResponse<IEnumerable<Utility>>(mappedApplications, utilities.Count());

      return new OkObjectResult(paginatedResponse);
    }

    public IActionResult GetWaterUtilities()
    {
      var currentDate = DateTime.Now;
      var utilities = this._context.Utilities
      .Where(m => m.UtilityType == UtilityType.Water).ToList();

      var mappedApplications = this._mapper.Map<IEnumerable<Utility>>(utilities);
      var paginatedResponse = new ApiPaginatedResponse<IEnumerable<Utility>>(mappedApplications, utilities.Count());

      return new OkObjectResult(paginatedResponse);
    }




  }
}
