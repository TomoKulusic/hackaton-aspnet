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
        [HttpGet("eForCurrentMonth")]
        public IActionResult GetUtilitiesForCurrentMonthElectricity()
        {
            return this._utilitiesService.GetUtilitiesForCurrentMonthElectricity();
        }
        [HttpGet("electricity")]
        public IActionResult GetElectricityUtilities()
        {
            return this._utilitiesService.GetElectricityUtilities();
        }

        [HttpGet("water")]
        public IActionResult GetWaterUtilities()
        {
            return this._utilitiesService.GetWaterUtilities();
        }

        [HttpGet("wForCurrentMonth")]
        public IActionResult GetUtilitiesForCurrentMonthWater()
        {
            return this._utilitiesService.GetUtilitiesForCurrentMonthWater();
        }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     return "value";
        // }

        // // POST api/values
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
