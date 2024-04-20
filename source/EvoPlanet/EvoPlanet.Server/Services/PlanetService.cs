using EvoPlanet.Server.Models;
using System.Text.Json;
using MongoDB.Driver;

namespace EvoPlanet.Server.Services
{
    public class PlanetService
    {
        private readonly IMongoCollection<Planet> _planets;

        public PlanetService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("evoPlanet");
            _planets = database.GetCollection<Planet>("Planet");
        }

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

        public async Task<Planet> CreateAsync(Planet planet)
        {
            await _planets.InsertOneAsync(planet);
            return planet;
        }

    }
}
