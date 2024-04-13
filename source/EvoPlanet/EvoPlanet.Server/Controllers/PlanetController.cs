using EvoPlanet.Server.Models;
using EvoPlanet.Server.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace EvoPlanet.Server.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class PlanetController : ControllerBase
    {
        private readonly PlanetService _service;
        public PlanetController(PlanetService Pservice)
        {
            _service = Pservice;
        }

        [HttpGet(Name ="GetPlanet")]
        public IActionResult GetPlanet()
        {
            Planet planet = _service.PlanetResult();
            return Ok(planet);
        }

        [HttpPost("WritePlanetData")]
        public IActionResult WritePlanetData()
        {
            //Use html body later!!!!
            
            _service.SaveData();
            return Ok();
        }
    }
}
