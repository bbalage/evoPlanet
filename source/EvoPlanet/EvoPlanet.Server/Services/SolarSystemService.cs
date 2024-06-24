using EvoPlanet.Server.Models;
using MongoDB.Driver;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace EvoPlanet.Server.Services
{
    public class SolarSystemService : ISolarSystemService
    {
        private const string DB_FILE_NAME = "solarSystems.json";
        private readonly IMongoCollection<SolarSystem> _sSystem;
        private JsonSerializerOptions _defaultJsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

        public SolarSystemService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("evoPlanet");
            _sSystem = database.GetCollection<SolarSystem>("SolarSystems");
        }

        // MongoDB
        public async Task<List<SolarSystem>> GetAllAsync()
        {
            return await _sSystem.Find(_ => true).ToListAsync();
        }

        public async Task<SolarSystem> CreateAsync(SolarSystem sSys)
        {
            await _sSystem.InsertOneAsync(sSys);
            return sSys;
        }

        public async Task UpdateAsync(string solarSystemId, SolarSystem updatedSolarSystem)
        {
            var filter = Builders<SolarSystem>.Filter.Eq(s => s.Id, solarSystemId);
            var result = await _sSystem.ReplaceOneAsync(filter, updatedSolarSystem);

            if (result.MatchedCount == 0)
            {
                throw new InvalidOperationException("SolarSystem not found.");
            }
        }

        public async Task DeleteAsync(string solarSystemId)
        {
            var filter = Builders<SolarSystem>.Filter.Eq(s => s.Id, solarSystemId);
            var result = await _sSystem.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                throw new InvalidOperationException("SolarSystem not found.");
            }
        }

        // JSON
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

        public void UpdateSolarSystem(string solarSystemID, SolarSystem updatedSolarSystem)
        {
            List<SolarSystem> solarSystems = GetAllSolarSystems();

            if (solarSystems.Count > 0)
            {
                SolarSystem? solarSystemToUpdate = solarSystems.Find(s => s.Id == solarSystemID);

                if (solarSystemToUpdate != null)
                {
                    solarSystemToUpdate.Name = updatedSolarSystem.Name;
                    solarSystemToUpdate.CelestialBodies = updatedSolarSystem.CelestialBodies;
                    SaveData(solarSystems);
                    return;
                }
            }

            throw new InvalidOperationException("SolarSystem not found.");
        }

        public void DeleteSolarSystem(string solarSystemID)
        {
            List<SolarSystem> solarSystems = GetAllSolarSystems();

            if (solarSystems.Count > 0)
            {
                SolarSystem? solarSystemToDelete = solarSystems.Find(s => s.Id == solarSystemID);

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
