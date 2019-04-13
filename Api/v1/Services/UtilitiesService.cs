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

namespace SmartHousing.API.v1.Services
{
  public interface IUtilitesService
  {
    IActionResult GetUtilitiesForCurrentMonthElectricity();
    IActionResult GetUtilitiesForCurrentMonthWater();
    IActionResult GetWaterUtilities();
    IActionResult GetElectricityUtilities();



  }

  public class UtilitesService : IUtilitesService
  {
    private readonly SmartHousingContext _context;
    private readonly IMapper _mapper;

    public UtilitesService(SmartHousingContext context, IMapper mapper)
    {
      this._context = context;
      this._mapper = mapper;
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
