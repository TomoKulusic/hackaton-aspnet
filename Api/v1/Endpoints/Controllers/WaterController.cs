using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartHousing.API.Database.Models;
using SmartHousing.API.v1.Services;

namespace SmartHousing.API.v1.Endpoints.Controllers
{
  [Route("api/v1/[controller]")]
  public class WaterController : ControllerBase
  {
    private readonly IWaterService _waterService;
    private readonly IUtilitesService _utilityService;


    public WaterController(IWaterService waterService, IUtilitesService utilityService)
    {
      this._waterService = waterService;
      this._utilityService = utilityService;

    }

    // GET api/values
    [HttpPost]
    [HttpPost]
    public IActionResult Post([FromBody]Water water)
    {
      var newUtility = _waterService.Post(water);
      return this._utilityService.GenerateWaterUtility((API.Bal.Models.Water)newUtility);
    }

  }
}
