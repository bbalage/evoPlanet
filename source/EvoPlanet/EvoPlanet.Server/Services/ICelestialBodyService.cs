using EvoPlanet.Server.Models;

namespace EvoPlanet.Server.Services
{
    public interface ICelestialBodyService
    {
        public Task UpdateAsync(int id, CelestialBody cBody);

        public Task<List<CelestialBody>> GetAllAsync();

        public Task<CelestialBody> CreateAsync(CelestialBody cBody);

        public Task<CelestialBody> GetById(int id);

        public Task DeleteAsync(int celestialBodyId);
    }
}
