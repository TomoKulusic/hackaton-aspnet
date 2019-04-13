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
  public class ElectricityController : ControllerBase
  {
    // GET api/values
    private readonly IElectricityService _electricityService;
    private readonly IUtilitesService _utilityService;


    public ElectricityController(IElectricityService electricityService, IUtilitesService utilityService)
    {
      this._electricityService = electricityService;
      this._utilityService = utilityService;
    }

    // GET api/values
    [HttpPost]
    public IActionResult Post([FromBody]Electricity electricity)
    {
      var newUtility = _electricityService.Post(electricity);
      return this._utilityService.GenerateElectricityUtility((API.Bal.Models.Electricity)newUtility);
    }
  }
}
