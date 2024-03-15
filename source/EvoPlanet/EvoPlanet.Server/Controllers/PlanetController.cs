using EvoPlanet.Server.Models;
using EvoPlanet.Server.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EvoPlanet.Server.Controllers
{
    //[System.Web.Http.Cors.DisableCors]
    [EnableCors]
    [ApiController]
    [Route("api/[controller]")]
    public class PlanetController : ControllerBase
    {
        private readonly PlanetService _servcie;
        public PlanetController(PlanetService Pservice)
        {
            _servcie = Pservice;
        }

        [DisableCors]
        [HttpGet(Name ="GetPlanet")]
        public IActionResult GetPlanet()
        {
            Planet planet = _servcie.PlanetResult();
            return Ok(planet);
        }

        [HttpPost("WritePlanetData")]
        public IActionResult WritePlanetData()
        {
            //Use html body later!!!!
            
            _servcie.SaveData();
            return Ok();
        }
    }
}
