using EvoPlanet.Server.Models;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace EvoPlanet.Server.Services
{
    public class SolarSystemService : ISolarSystemService
    {
        private const string DB_FILE_NAME = "valami.json";

        private JsonSerializerOptions _defaultJsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

        private readonly IMongoCollection<SolarSystem> _sSystem;

        public SolarSystemService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("evoPlanet");
            _sSystem = database.GetCollection<SolarSystem>("Solarsystem");
        }


        public async Task<List<SolarSystem>> GetAllAsync()
        {
            return await _sSystem.Find(ss => true).ToListAsync();
        }

        public async Task<SolarSystem> GetByIdAsync(int id)
        {
            return await _sSystem.Find<SolarSystem>(ss => ss.Id == id).FirstOrDefaultAsync();
        }

        /*
        public async Task<List<SolarSystem>> GetByUserAsync(string userId)
        {
            return await _sSystem.Find(s => s.User == userId).ToListAsync();
        }
        */

        public async Task<SolarSystem> CreateAsync(SolarSystem solarsystem)
        {
            await _sSystem.InsertOneAsync(solarsystem);
            return solarsystem;
        }

        public async Task UpdateAsync(int id, SolarSystem solarsystem)
        {
            await _sSystem.ReplaceOneAsync(ss => ss.Id == id, solarsystem);
        }

        public async Task DeleteAsync(int id)
        {
            await _sSystem.DeleteOneAsync(ss => ss.Id == id);
        }

        public List<SolarSystem> GetAllSolarSystems()
        {
            try
            {
                string jsonData = DataBase.ReadData(DB_FILE_NAME);
                List<SolarSystem>? solarSystems = JsonSerializer.Deserialize<List<SolarSystem>>(jsonData);
                return solarSystems ?? new List<SolarSystem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
                return new List<SolarSystem>();
            }
        }

        public void SaveData(List<SolarSystem> solarSystems)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(solarSystems, _defaultJsonSerializerOptions);
                DataBase.SaveData(DB_FILE_NAME, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during serialization: {ex.Message}");
            }
        }

        public void AddSolarSystem(SolarSystem newSolarSystem)
        {
            List<SolarSystem> solarSystems = GetAllSolarSystems();
            solarSystems.Add(newSolarSystem);
            SaveData(solarSystems);
        }

        public void UpdateSolarSystem(int solarSystemId, SolarSystem updatedSolarSystem)
        {
            List<SolarSystem> solarSystems = GetAllSolarSystems();

            if (solarSystems.Count > 0)
            {
                SolarSystem? solarSystemToUpdate = solarSystems.Find(c => c.Id == solarSystemId);

                if (solarSystemToUpdate != null)
                {
                    solarSystemToUpdate.Name = updatedSolarSystem.Name;
                    solarSystemToUpdate.PX = updatedSolarSystem.PX;
                    solarSystemToUpdate.PY = updatedSolarSystem.PY;
                    solarSystemToUpdate.VX = updatedSolarSystem.VX;
                    solarSystemToUpdate.VY = updatedSolarSystem.VY;
                    solarSystemToUpdate.Radius = updatedSolarSystem.Radius;
                    solarSystemToUpdate.Mass = updatedSolarSystem.Mass;
                    SaveData(solarSystems);
                    return;
                }
            }

            throw new InvalidOperationException("SolarSytem not found.");
        }

        public void DeleteSolarSystem(int solarSystemId)
        {
            List<SolarSystem> solarSystems = GetAllSolarSystems();

            if (solarSystems.Count > 0)
            {
                SolarSystem? solarSystemToDelete = solarSystems.Find(c => c.Id == solarSystemId);

                if (solarSystemToDelete != null)
                {
                    solarSystems.Remove(solarSystemToDelete);
                    SaveData(solarSystems);
                    return;
                }
            }

            throw new InvalidOperationException("SolarSystem not found.");
        }
     
    }
}
