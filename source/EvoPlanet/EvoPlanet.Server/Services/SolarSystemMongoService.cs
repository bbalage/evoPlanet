using EvoPlanet.Server.Models;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace EvoPlanet.Server.Services
{
    public class SolarSystemMongoService : ISolarSystemService
    {
       
        private readonly IMongoCollection<SolarSystem> _sSystem;

        public SolarSystemMongoService()
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
            return await _sSystem.Find(ss => ss.User == userId).ToListAsync();
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

        public async Task<SolarSystem> GetById(int id)
        {
            return await _sSystem.Find(ss => ss.Id == id).FirstOrDefaultAsync();
        }
    }
}
