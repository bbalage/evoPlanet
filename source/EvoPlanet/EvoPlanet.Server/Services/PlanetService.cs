using EvoPlanet.Server.Models;
using System.Text.Json;

namespace EvoPlanet.Server.Services
{
    public class PlanetService
    {
        //File read
        public Planet PlanetResult()
        {
            Planet planet = JsonSerializer.Deserialize<Planet>(DataBase.ReadData("valami.json"))!;
            return planet; 
        }

        //File write
        public void SaveData()
        {
            Planet planet = new Planet();
            planet.Name = "Jupiter";
            planet.PX = 0;
            planet.PY = 0;
            planet.VX = 10;
            planet.VY = 20;
            planet.Radius = 3;
            planet.Mass = 2;
            DataBase.SaveData("valami.json", JsonSerializer.Serialize(planet));
        }
    }
}
