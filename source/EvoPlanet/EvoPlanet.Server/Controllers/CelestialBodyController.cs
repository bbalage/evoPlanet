using EvoPlanet.Server.Models;
using EvoPlanet.Server.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        // JSON Methods
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("json")]
        public IActionResult GetCelestialBodies()
        {
            var celestialBodies = _celestialBodyService.GetAllCelestialBodies();
            return Ok(celestialBodies);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("json/{celestialBodyID}")]
        public IActionResult GetCelestialBodyById(Guid celestialBodyID)
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
        [HttpPost("json")]
        public IActionResult AddCelestialBody([FromBody] CelestialBody newCelestialBody)
        {
            _celestialBodyService.AddCelestialBody(newCelestialBody);
            return Ok();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("json/{celestialBodyID}")]
        public IActionResult UpdateCelestialBody(Guid celestialBodyID, [FromBody] CelestialBody updatedCelestialBody)
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
        [HttpDelete("json/{celestialBodyID}")]
        public IActionResult DeleteCelestialBody(Guid celestialBodyID)
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

        // MongoDB Methods
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("mongo")]
        public async Task<IActionResult> GetCelestialBodiesMongo()
        {
            var celestialBodies = await _celestialBodyService.GetAllAsync();
            return Ok(celestialBodies);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("mongo/{celestialBodyID}")]
        public async Task<IActionResult> GetCelestialBodyByIdMongo(Guid celestialBodyID)
        {
            var celestialBodies = await _celestialBodyService.GetAllAsync();
            var celestialBody = celestialBodies.FirstOrDefault(c => c.CelestialBodyID == celestialBodyID);
            if (celestialBody != null)
            {
                return Ok(celestialBody);
            }
            else
            {
                return NotFound("CelestialBody not found.");
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost("mongo")]
        public async Task<IActionResult> AddCelestialBodyMongo([FromBody] CelestialBody newCelestialBody)
        {
            var createdCelestialBody = await _celestialBodyService.CreateAsync(newCelestialBody);
            return Ok(createdCelestialBody);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("mongo/{celestialBodyID}")]
        public async Task<IActionResult> UpdateCelestialBodyMongo(Guid celestialBodyID, [FromBody] CelestialBody updatedCelestialBody)
        {
            try
            {
                await _celestialBodyService.UpdateAsync(celestialBodyID, updatedCelestialBody);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("mongo/{celestialBodyID}")]
        public async Task<IActionResult> DeleteCelestialBodyMongo(Guid celestialBodyID)
        {
            try
            {
                await _celestialBodyService.DeleteAsync(celestialBodyID);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
