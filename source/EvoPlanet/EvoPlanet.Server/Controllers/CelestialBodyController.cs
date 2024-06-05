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

        /*[EnableCors("_myAllowSpecificOrigins")]
        [HttpGet]
        public async Task<IActionResult> GetCelestialBodiesMongoDB()
        {
            var celestialBodies = await _celestialBodyService.GetAllAsync();
            return Ok(celestialBodies);
        }*/

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{celestialBodyID}")]
        public IActionResult GetCelestialBodyByI(int celestialBodyID)
        {
            try
            {
                var celestialBody = _celestialBodyService.GetAllCelestialBodies().FirstOrDefault(c => c.CelestialBodyID == celestialBodyID);
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
        public IActionResult AddCelestialBody([FromBody] CelestialBodyDTO newCelestialBody)
        {
            _celestialBodyService.AddCelestialBody(newCelestialBody);
            return Ok();

        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{celestialBodyID}")]
        public IActionResult UpdateCelestialBody(int celestialBodyID, CelestialBodyDTO updatedCelestialBody)
        {
            try
            {
                _celestialBodyService.UpdateCelestialBody(celestialBodyID, updatedCelestialBody);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{celestialBodyID}")]
        public IActionResult DeleteCelestialBody(int celestialBodyID)
        {
            try
            {
                _celestialBodyService.DeleteCelestialBody(celestialBodyID);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
