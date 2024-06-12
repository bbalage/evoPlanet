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
        public async Task<IActionResult> GetCelestialBodies()
        {
            var celestialBodies = await _celestialBodyService.GetAllAsync();

            return Ok(celestialBodies);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("{celestialBodyId}")]

        public async Task<IActionResult> GetCelestialBodyById(int celestialBodyId)
        {
            try
            {
                var celestialBody =await _celestialBodyService.GetById(celestialBodyId);
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

        public async Task<IActionResult> AddCelestialBody([FromBody] CelestialBody newCelestialBody)
        {
            //_celestialBodyService.AddCelestialBody(newCelestialBody);
            CelestialBody cBody = await _celestialBodyService.CreateAsync(newCelestialBody);
            return Ok(cBody);
            //return Ok();

        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("{celestialBodyId}")]
        public async Task<IActionResult> UpdateCelestialBody(int celestialBodyId, CelestialBody updatedCelestialBody)
        {
            try
            {
                await _celestialBodyService.UpdateAsync(celestialBodyId, updatedCelestialBody);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("{celestialBodyId}")]
        public async Task<IActionResult> DeleteCelestialBody(int celestialBodyId)
        {
            try
            {
                await _celestialBodyService.DeleteAsync(celestialBodyId);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
