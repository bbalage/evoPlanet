using EvoPlanet.Server.Models;
using System.Text.Json;
using MongoDB.Driver;

namespace EvoPlanet.Server.Services
{
    public class CelestialBodyService : ICelestialBodyService
    {
        private const string DB_FILE_NAME = "valami.json";
        private readonly IMongoCollection<CelestialBody> _cBodies;

        public CelestialBodyService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("evoPlanet");
            _cBodies = database.GetCollection<CelestialBody>("Celestialbodies");
        }

        public async Task<List<CelestialBody>> GetAllAsync()
        {
            return await _cBodies.Find(cb => true).ToListAsync();
        }

        public async Task<CelestialBody> CreateAsync(CelestialBody cBody)
        {
            await _cBodies.InsertOneAsync(cBody);
            return cBody;
        }


        private JsonSerializerOptions _defaultJsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

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

        public void UpdateCelestialBody(int celestialBodyId, CelestialBody updatedCelestialBody)
        {
            List<CelestialBody> celestialBodies = GetAllCelestialBodies();

            if (celestialBodies.Count > 0)
            {
                CelestialBody? celestialBodyToUpdate = celestialBodies.Find(c => c.Id == celestialBodyId);

                if (celestialBodyToUpdate != null)
                {
                    celestialBodyToUpdate.Name = updatedCelestialBody.Name;
                    celestialBodyToUpdate.PX = updatedCelestialBody.PX;
                    celestialBodyToUpdate.PY = updatedCelestialBody.PY;
                    celestialBodyToUpdate.VX = updatedCelestialBody.VX;
                    celestialBodyToUpdate.VY = updatedCelestialBody.VY;
                    celestialBodyToUpdate.Radius = updatedCelestialBody.Radius;
                    celestialBodyToUpdate.Mass = updatedCelestialBody.Mass;
                    SaveData(celestialBodies);
                    return;
                }
            }

            throw new InvalidOperationException("CelestialBody not found.");
        }

        public void DeleteCelestialBody(int celestialBodyId)
        {
            List<CelestialBody> CelestialBodies = GetAllCelestialBodies();

            if (CelestialBodies.Count > 0)
            {
                CelestialBody? celestialBodyToDelete = CelestialBodies.Find(c => c.Id == celestialBodyId);

                if (celestialBodyToDelete != null)
                {
                    CelestialBodies.Remove(celestialBodyToDelete);
                    SaveData(CelestialBodies);
                    return;
                }
            }

            throw new InvalidOperationException("CelestialBody not found.");
        }

    }
}
