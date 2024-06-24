using EvoPlanet.Server.Models;
using MongoDB.Driver;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;

namespace EvoPlanet.Server.Services
{
    public class CelestialBodyService : ICelestialBodyService
    {
        private const string DB_FILE_NAME = "celestialBodies.json";
        private readonly IMongoCollection<CelestialBody> _cBodies;
        private JsonSerializerOptions _defaultJsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

        public CelestialBodyService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("evoPlanet");
            _cBodies = database.GetCollection<CelestialBody>("CelestialBodies");
        }

        // MongoDB
        public async Task<List<CelestialBody>> GetAllAsync()
        {
            return await _cBodies.Find(_ => true).ToListAsync();
        }

        public async Task<CelestialBody> CreateAsync(CelestialBody cBody)
        {
            await _cBodies.InsertOneAsync(cBody);
            return cBody;
        }

        public async Task UpdateAsync(string celestialBodyId, CelestialBody updatedCelestialBody)
        {
            var filter = Builders<CelestialBody>.Filter.Eq(c => c.CelestialBodyID, celestialBodyId);
            var result = await _cBodies.ReplaceOneAsync(filter, updatedCelestialBody);

            if (result.MatchedCount == 0)
            {
                throw new InvalidOperationException("CelestialBody not found.");
            }
        }

        public async Task DeleteAsync(string celestialBodyId)
        {
            var filter = Builders<CelestialBody>.Filter.Eq(c => c.CelestialBodyID, celestialBodyId);
            var result = await _cBodies.DeleteOneAsync(filter);

            if (result.DeletedCount == 0)
            {
                throw new InvalidOperationException("CelestialBody not found.");
            }
        }

        // JSON
        public List<CelestialBody> GetAllCelestialBodies()
        {
            try
            {
                string jsonData = DataBase.ReadData(DB_FILE_NAME);
                List<CelestialBody>? celestialBodies = JsonSerializer.Deserialize<List<CelestialBody>>(jsonData);
                return celestialBodies ?? new List<CelestialBody>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
                return new List<CelestialBody>();
            }
        }

        public void SaveData(List<CelestialBody> celestialBodies)
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(celestialBodies, _defaultJsonSerializerOptions);
                DataBase.SaveData(DB_FILE_NAME, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during serialization: {ex.Message}");
            }
        }

        public void AddCelestialBody(CelestialBody newCelestialBody)
        {
            List<CelestialBody> celestialBodies = GetAllCelestialBodies();
            celestialBodies.Add(newCelestialBody);
            SaveData(celestialBodies);
        }

        public void UpdateCelestialBody(string celestialBodyID, CelestialBody updatedCelestialBody)
        {
            List<CelestialBody> celestialBodies = GetAllCelestialBodies();

            if (celestialBodies.Count > 0)
            {
                CelestialBody? celestialBodyToUpdate = celestialBodies.Find(c => c.CelestialBodyID == celestialBodyID);

                if (celestialBodyToUpdate != null)
                {
                    celestialBodyToUpdate.Name = updatedCelestialBody.Name;
                    celestialBodyToUpdate.Mass = updatedCelestialBody.Mass;
                    celestialBodyToUpdate.Radius = updatedCelestialBody.Radius;
                    celestialBodyToUpdate.Mass = updatedCelestialBody.Mass;
                    SaveData(celestialBodies);
                    return;
                }
            }

            throw new InvalidOperationException("CelestialBody not found.");
        }

        public void DeleteCelestialBody(string celestialBodyID)
        {
            List<CelestialBody> celestialBodies = GetAllCelestialBodies();

            if (celestialBodies.Count > 0)
            {
                CelestialBody? celestialBodyToDelete = celestialBodies.Find(c => c.CelestialBodyID == celestialBodyID);

                if (celestialBodyToDelete != null)
                {
                    celestialBodies.Remove(celestialBodyToDelete);
                    SaveData(celestialBodies);
                    return;
                }
            }

            throw new InvalidOperationException("CelestialBody not found.");
        }

    }
}
