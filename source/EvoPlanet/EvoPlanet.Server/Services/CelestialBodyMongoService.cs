using EvoPlanet.Server.Models;
using System.Text.Json;
using MongoDB.Driver;

namespace EvoPlanet.Server.Services
{
    public class CelestialBodyMongoService : ICelestialBodyService
    {
        private const string DB_FILE_NAME = "valami.json";
        private readonly IMongoCollection<CelestialBody> _cBodies;

        public CelestialBodyMongoService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("evoPlanet");
            _cBodies = database.GetCollection<CelestialBody>("Celestialbodies");
        }

        public async Task<List<CelestialBody>> GetAllAsync()
        {
            return await _cBodies.Find(cb => true).ToListAsync();
        }

        //Change id to GUID
        public async Task<CelestialBody> GetById(int id)
        {
            return await _cBodies.Find<CelestialBody>(cb => cb.Id == id).FirstOrDefaultAsync();
        }

        public async Task<CelestialBody> CreateAsync(CelestialBody cBody)
        {
            await _cBodies.InsertOneAsync(cBody);
            return cBody;
        }


        private JsonSerializerOptions _defaultJsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };



        public async Task UpdateAsync(int id, CelestialBody cBody)
        {
            await _cBodies.ReplaceOneAsync(cb => cb.Id == id, cBody);
        }

        public async Task DeleteAsync(int celestialBodyId)
        {
           await _cBodies.DeleteOneAsync(cb => cb.Id == celestialBodyId);
        }

        /*
        public async Task<List<CelestialBody>> GetByUserAsync(string userId)
        {
            return await _cBodies.Find(cb => cb.User == userId).ToListAsync();
        }
        */

    }
}
