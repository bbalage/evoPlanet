using EvoPlanet.Server.Models;

namespace EvoPlanet.Server.Services
{
    public interface ISolarSystemService
    {

        public Task UpdateAsync(int id, SolarSystem sSystem);

        public Task<List<SolarSystem>> GetAllAsync();

        public Task<SolarSystem> CreateAsync(SolarSystem sSystem);

        public Task<SolarSystem> GetById(int id);

        public Task DeleteAsync(int solarSystemId);
    }
}
