using EvoPlanet.Server.Models;
using System.Text.Json;
using MongoDB.Driver;

namespace EvoPlanet.Server.Services
{
    public class CelestialBodyService : ICelestialBodyService
    {
        private const string DB_FILE_NAME = "valami.json";
        private readonly IMongoCollection<CelestialBodyDTO> _cBodies;
        private JsonSerializerOptions _defaultJsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
        private int _currentID;

        public CelestialBodyService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("evoPlanet");
            _cBodies = database.GetCollection<CelestialBodyDTO>("Celestialbodies");
            _currentID = GetMaxID();
        }

        private int GetMaxID()
        {
            var celestialBodies = GetAllCelestialBodies();
            return celestialBodies.Any() ? celestialBodies.Max(c => c.CelestialBodyID) : 0;
        }

        //MongoDB
        public async Task<List<CelestialBodyDTO>> GetAllAsync()
        {
            return await _cBodies.AsQueryable().ToListAsync();
        }

        public async Task<CelestialBodyDTO> CreateAsync(CelestialBodyDTO cBody)
        {
            cBody.CelestialBodyID = ++_currentID;
            await _cBodies.InsertOneAsync(cBody);
            return cBody;
        }

        //JSON
        public List<CelestialBodyDTO> GetAllCelestialBodies()
        {
            try
            {
                string jsonData = DataBase.ReadData(DB_FILE_NAME);
                List<CelestialBodyDTO>? celestialBodies = JsonSerializer.Deserialize<List<CelestialBodyDTO>>(jsonData);
                return celestialBodies ?? new List<CelestialBodyDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
                return new List<CelestialBodyDTO>();
            }
        }

        public void SaveData(List<CelestialBodyDTO> celestialBodies)
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

        public void AddCelestialBody(CelestialBodyDTO newCelestialBody)
        {
            newCelestialBody.CelestialBodyID = ++_currentID;
            List<CelestialBodyDTO> celestialBodies = GetAllCelestialBodies();
            celestialBodies.Add(newCelestialBody);
            SaveData(celestialBodies);
        }

        public void UpdateCelestialBody(int celestialBodyID, CelestialBodyDTO updatedCelestialBody)
        {
            List<CelestialBodyDTO> celestialBodies = GetAllCelestialBodies();

            if (celestialBodies.Count > 0)
            {
                CelestialBodyDTO? celestialBodyToUpdate = celestialBodies.Find(c => c.CelestialBodyID == celestialBodyID);

                if (celestialBodyToUpdate != null)
                {
                    celestialBodyToUpdate.Name = updatedCelestialBody.Name;
                    celestialBodyToUpdate.Mass = updatedCelestialBody.Mass;
                    celestialBodyToUpdate.Radius = updatedCelestialBody.Radius;
                    SaveData(celestialBodies);
                    return;
                }
            }

            throw new InvalidOperationException("CelestialBody not found.");
        }

        public void DeleteCelestialBody(int celestialBodyID)
        {
            List<CelestialBodyDTO> CelestialBodies = GetAllCelestialBodies();

            if (CelestialBodies.Count > 0)
            {
                CelestialBodyDTO? celestialBodyToDelete = CelestialBodies.Find(c => c.CelestialBodyID == celestialBodyID);

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

