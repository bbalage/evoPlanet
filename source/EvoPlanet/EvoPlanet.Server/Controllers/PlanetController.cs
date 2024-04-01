using EvoPlanet.Server.Models;
using EvoPlanet.Server.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EvoPlanet.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlanetController : ControllerBase
    {
        private readonly IPlanetService _planetService;

        public PlanetController(IPlanetService planetService)
        {
            _planetService = planetService;
        }

        [HttpGet]
        public IActionResult GetPlanets()
        {
            var planets = _planetService.GetAllPlanets();
            return Ok(planets);
        }

        [HttpPost]
        public IActionResult AddPlanet(Planet newPlanet)
        {
            _planetService.AddPlanet(newPlanet);
            return Ok();
        }

        [HttpPut("{planetName}")]
        public IActionResult UpdatePlanet(string planetName, Planet updatedPlanet)
        {
            try
            {
                _planetService.UpdatePlanet(planetName, updatedPlanet);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{planetName}")]
        public IActionResult DeletePlanet(string planetName)
        {
            try
            {
                _planetService.DeletePlanet(planetName);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
