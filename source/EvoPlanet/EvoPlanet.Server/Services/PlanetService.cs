using EvoPlanet.Server.Models;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace EvoPlanet.Server.Services
{
    public class PlanetService : IPlanetService
    {
        private const string DB_FILE_NAME = "valami.json";

        private JsonSerializerOptions _defaultJsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

        public List<Planet> GetAllPlanets()
        {
            try
            {
                string jsonData = DataBase.ReadData(DB_FILE_NAME);
                List<Planet>? planets = JsonSerializer.Deserialize<List<Planet>>(jsonData);
                return planets ?? new List<Planet>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
                return new List<Planet>();
            }
        }

        public void SaveData(List<Planet> planets)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(planets, _defaultJsonSerializerOptions);
                DataBase.SaveData(DB_FILE_NAME, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during serialization: {ex.Message}");
            }
        }

        public void AddPlanet(Planet newPlanet)
        {
            List<Planet> planets = GetAllPlanets();
            planets.Add(newPlanet);
            SaveData(planets);
        }

        public void UpdatePlanet(string planetName, Planet updatedPlanet)
        {
            List<Planet> planets = GetAllPlanets();
            Planet? planetToUpdate = planets.Find(p => p.Name == planetName);

            if (planetToUpdate != null)
            {
                planetToUpdate.PX = updatedPlanet.PX;
                planetToUpdate.PY = updatedPlanet.PY;
                planetToUpdate.VX = updatedPlanet.VX;
                planetToUpdate.VY = updatedPlanet.VY;
                planetToUpdate.Radius = updatedPlanet.Radius;
                planetToUpdate.Mass = updatedPlanet.Mass;
                SaveData(planets);
            }
            else
            {
                Console.WriteLine("Planet not found.");
            }
        }

        public void DeletePlanet(string planetName)
        {
            List<Planet> planets = GetAllPlanets();
            Planet? planetToDelete = planets.Find(p => p.Name == planetName);

            if (planetToDelete != null)
            {
                planets.Remove(planetToDelete);
                SaveData(planets);
            }
            else
            {
                Console.WriteLine("Planet not found.");
            }
        }
    }
}
