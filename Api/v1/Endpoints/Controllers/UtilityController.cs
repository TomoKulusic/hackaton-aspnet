using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartHousing.API.v1.Services;

namespace SmartHousing.API.v1.Endpoints.Controllers
{
    [Route("api/v1/[controller]")]
    public class UtilitiesController : ControllerBase
    {
        private readonly IUtilitesService _utilitiesService;
    
        public UtilitiesController(IUtilitesService utilitiesService) {
             this._utilitiesService = utilitiesService;
        }

        // GET api/values
        [HttpGet("electricityCurrentMonth")]
        public IActionResult GetUtilitiesForCurrentMonthElectricity()
        {   
            return this._utilitiesService.GetUtilitiesForCurrentMonthElectricity();
        }
        [HttpGet("getAllElectricity")]
        public IActionResult GetElectricityUtilities()
        {
            return this._utilitiesService.GetElectricityUtilities();
        }

        [HttpGet("getAllWater")]
        public IActionResult GetWaterUtilities()
        {
            return this._utilitiesService.GetWaterUtilities();
        }

        [HttpGet("waterCurrentMonth")]
        public IActionResult GetUtilitiesForCurrentMonthWater()
        {
            return this._utilitiesService.GetUtilitiesForCurrentMonthWater();
        }

        [HttpGet("getWaterByMonth")]
        public IActionResult GetWaterByMonth([FromForm] int month)
        {
            return this._utilitiesService.GetWaterByMonth(month);
        }

        [HttpGet("getElectricityByMonth")]
        public IActionResult GetElectricityByMonth([FromForm] int month)
        {
            return this._utilitiesService.GetElectricityByMonth(month);
        }

        
    }
}
