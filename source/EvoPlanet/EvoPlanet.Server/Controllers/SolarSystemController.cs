using EvoPlanet.Server.Models;
using EvoPlanet.Server.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EvoPlanet.Server.Controllers
{
    public class IdHandler
    {
        [JsonPropertyName("id")]
        public string id { get; set; } = string.Empty;
    }


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

        // JSON Methods
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("json")]
        public IActionResult GetAllSolarSystems()
        {
            var solarSystems = _solarSystemService.GetAllSolarSystems();
            return Ok(solarSystems);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("json/{solarSystemID}")]
        public IActionResult GetSolarSystemById(Guid solarSystemID)
        {
            try
            {
                var solarSystem = _solarSystemService.GetAllSolarSystems().FirstOrDefault(c => c.Id == solarSystemID.ToString());
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
        [HttpPost("json")]
        public IActionResult AddSolarSystem([FromBody] SolarSystem newSolarSystem)
        {
            _solarSystemService.AddSolarSystem(newSolarSystem);
            return Ok();
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("json/{solarSystemID}")]
        public IActionResult UpdateSolarSystem(string solarSystemID, [FromBody] SolarSystem updatedSolarSystem)
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
        [HttpDelete("json/{solarSystemID}")]
        public IActionResult DeleteSolarSystem(string solarSystemID)
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

        // MongoDB Methods
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpGet("mongo")]
        public async Task<IActionResult> GetAllSolarSystemsMongo()
        {
            var solarSystems = await _solarSystemService.GetAllAsync();
            return Ok(solarSystems);
    }


        //example: https://localhost:7081/api/SolarSystem/mongo/getOne667adf86b7477c4b4fc38de9
        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost("mongo/getOne")]
        public async Task<IActionResult> GetSolarSystemByIdMongo([FromBody]IdHandler handler)
        {
            var solarSystem = await _solarSystemService.GetById(handler.id);
            if (solarSystem != null)
            {
                return Ok(solarSystem);
            }
            else
            {
                return NotFound("SolarSystem not found.");
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPost("mongo")]
        public async Task<IActionResult> AddSolarSystemMongo([FromBody] SolarSystem newSolarSystem)
        {
            var createdSolarSystem = await _solarSystemService.CreateAsync(newSolarSystem);
            return Ok(createdSolarSystem);
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpPut("mongo/{solarSystemID}")]
        public async Task<IActionResult> UpdateSolarSystemMongo(string solarSystemID, [FromBody] SolarSystem updatedSolarSystem)
        {
            try
            {
                await _solarSystemService.UpdateAsync(solarSystemID, updatedSolarSystem);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [EnableCors("_myAllowSpecificOrigins")]
        [HttpDelete("mongo/{solarSystemID}")]
        public async Task<IActionResult> DeleteSolarSystemMongo(string solarSystemID)
        {
            try
            {
                await _solarSystemService.DeleteAsync(solarSystemID);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
