using EvoPlanet.Server.Models;
using EvoPlanet.Server.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EvoPlanet.Server.Controllers
{
    [EnableCors("_myAllowSpecificOrigins")]
    [ApiController]
    [Route("api/[controller]")]
    public class SolarSystemController : ControllerBase
    {
        private readonly ISolarSystemService _solarSystemService;

        public SolarSystemController(ISolarSystemService solarSystemService)
        {
            _solarSystemService = solarSystemService;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        public IActionResult GetAllSolarSystems()
        {
            var solarSystems = _solarSystemService.GetAllSolarSystems();
            return Ok(solarSystems);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{solarSystemID}")]
        public IActionResult GetSolarSystemById(int solarSystemID)
        {
            try
            {
                var solarSystem = _solarSystemService.GetAllSolarSystems().FirstOrDefault(c => c.SolarSystemID == solarSystemID);
                if (solarSystem != null)
                {
                    return Ok(solarSystem);
                }
                else
                {
                    return NotFound("SolarSystem not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        public IActionResult AddSolarSystem(SolarSystemDTO newSolarSystem)
        {
            _solarSystemService.AddSolarSystem(newSolarSystem);
            return Ok();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{solarSystemID}")]
        public IActionResult UpdateSolarSystem(int solarSystemID, SolarSystemDTO updatedSolarSystem)
        {
            try
            {
                _solarSystemService.UpdateSolarSystem(solarSystemID, updatedSolarSystem);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{solarSystemID}")]
        public IActionResult DeleteSolarSystem(int solarSystemID)
        {
            try
            {
                _solarSystemService.DeleteSolarSystem(solarSystemID);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

}
