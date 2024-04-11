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
        [HttpGet("{solarSystemId}")]
        public IActionResult GetSolarSystemById(int solarSystemId)
        {
            try
            {
                var solarSystem = _solarSystemService.GetAllSolarSystems().FirstOrDefault(c => c.Id == solarSystemId);
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
        public IActionResult AddSolarSystem(SolarSystem newSolarSystem)
        {
            _solarSystemService.AddSolarSystem(newSolarSystem);
            return Ok();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{solarSystemId}")]
        public IActionResult UpdateSolarSystem(int solarSystemId, SolarSystem updatedSolarSystem)
        {
            try
            {
                _solarSystemService.UpdateSolarSystem(solarSystemId, updatedSolarSystem);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{solarSystemId}")]
        public IActionResult DeleteSolarSystem(int solarSystemId)
        {
            try
            {
                _solarSystemService.DeleteSolarSystem(solarSystemId);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

}
