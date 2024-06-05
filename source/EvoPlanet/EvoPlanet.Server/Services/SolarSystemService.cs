using EvoPlanet.Server.Models;
using System.Text.Json;
using MongoDB.Driver;

namespace EvoPlanet.Server.Services
{
    public class SolarSystemService : ISolarSystemService
    {
        private const string DB_FILE_NAME = "valami.json";
        private readonly IMongoCollection<SolarSystemDTO> _sSystem;
        private JsonSerializerOptions _defaultJsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
        private int _currentID;

        public SolarSystemService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("evoPlanet");
            _sSystem = database.GetCollection<SolarSystemDTO>("SolarSystems");
            _currentID = GetMaxID();
        }
        private int GetMaxID()
        {
            var solarSystems = GetAllSolarSystems();
            return solarSystems.Any() ? solarSystems.Max(s => s.SolarSystemID) : 0;
        }

        //MongoDB
        public async Task<List<SolarSystemDTO>> GetAllAsync()
        {
            return await _sSystem.AsQueryable().ToListAsync();
        }

        public async Task<SolarSystemDTO> CreateAsync(SolarSystemDTO sSys)
        {
            sSys.SolarSystemID = ++_currentID;
            await _sSystem.InsertOneAsync(sSys);
            return sSys;
        }

        //JSON
        public List<SolarSystemDTO> GetAllSolarSystems()
        {
            try
            {
                string jsonData = DataBase.ReadData(DB_FILE_NAME);
                List<SolarSystemDTO>? solarSystems = JsonSerializer.Deserialize<List<SolarSystemDTO>>(jsonData);
                return solarSystems ?? new List<SolarSystemDTO>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
                return new List<SolarSystemDTO>();
            }
        }

        public void SaveData(List<SolarSystemDTO> solarSystems)
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

        public void AddSolarSystem(SolarSystemDTO newSolarSystem)
        {
            newSolarSystem.SolarSystemID = ++_currentID;
            List<SolarSystemDTO> solarSystems = GetAllSolarSystems();
            solarSystems.Add(newSolarSystem);
            SaveData(solarSystems);
        }

        public void UpdateSolarSystem(int solarSystemID, SolarSystemDTO updatedSolarSystem)
        {
            List<SolarSystemDTO> solarSystems = GetAllSolarSystems();

            if (solarSystems.Count > 0)
            {
                SolarSystemDTO? solarSystemToUpdate = solarSystems.Find(c => c.SolarSystemID == solarSystemID);

                if (solarSystemToUpdate != null)
                {
                    // Frissítsük a név mezőt
                    solarSystemToUpdate.Name = updatedSolarSystem.Name;

                    // Frissítsük a koordinátákat
                    if (updatedSolarSystem.Coordinate != null && updatedSolarSystem.Coordinate.Count > 0)
                    {
                        solarSystemToUpdate.Coordinate.Clear();
                        solarSystemToUpdate.Coordinate.AddRange(updatedSolarSystem.Coordinate);
                    }

                    // Frissítsük a sebességvektorokat
                    if (updatedSolarSystem.VelocityVector != null && updatedSolarSystem.VelocityVector.Count > 0)
                    {
                        solarSystemToUpdate.VelocityVector.Clear();
                        solarSystemToUpdate.VelocityVector.AddRange(updatedSolarSystem.VelocityVector);
                    }

                    // Adatok mentése
                    SaveData(solarSystems);
                    return;
                }
            }

            throw new InvalidOperationException("SolarSystem not found.");
        }


        public void DeleteSolarSystem(int solarSystemID)
        {
            List<SolarSystemDTO> solarSystems = GetAllSolarSystems();

            if (solarSystems.Count > 0)
            {
                SolarSystemDTO? solarSystemToDelete = solarSystems.Find(c => c.SolarSystemID == solarSystemID);

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
