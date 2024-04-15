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
    public class CelestialBodyController : ControllerBase
    {
        private readonly ICelestialBodyService _celestialBodyService;

        public CelestialBodyController(ICelestialBodyService celestialBodyService)
        {
            _celestialBodyService = celestialBodyService;
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        public IActionResult GetCelestialBodies()
        {
            var celestialBodies = _celestialBodyService.GetAllCelestialBodies();
            return Ok(celestialBodies);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{celestialBodyId}")]
        public IActionResult GetCelestialBodyById(int celestialBodyId)
        {
            try
            {
                var celestialBody = _celestialBodyService.GetAllCelestialBodies().FirstOrDefault(c => c.Id == celestialBodyId);
                if (celestialBody != null)
                {
                    return Ok(celestialBody);
                }
                else
                {
                    return NotFound("CelestialBody not found.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost]
        public IActionResult AddCelestialBody(CelestialBody newCelestialBody)
        {
            _celestialBodyService.AddCelestialBody(newCelestialBody);
            return Ok();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{celestialBodyId}")]
        public IActionResult UpdateCelestialBody(int celestialBodyId, CelestialBody updatedCelestialBody)
        {
            try
            {
                _celestialBodyService.UpdateCelestialBody(celestialBodyId, updatedCelestialBody);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{celestialBodyId}")]
        public IActionResult DeleteCelestialBody(int celestialBodyId)
        {
            try
            {
                _celestialBodyService.DeleteCelestialBody(celestialBodyId);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
