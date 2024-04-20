using EvoPlanet.Server.Models;

namespace EvoPlanet.Server.Services
{
    public interface ICelestialBodyService
    {
        List<CelestialBody> GetAllCelestialBodies();

        void SaveData(List<CelestialBody> celestialBodies);

        void AddCelestialBody(CelestialBody newCelestialBody);

        void UpdateCelestialBody(int celestialBodyId, CelestialBody updatedCelestialBody);

        void DeleteCelestialBody(int celestialBodyId);

        public Task<List<CelestialBody>> GetAllAsync();

        public Task<CelestialBody> CreateAsync(CelestialBody cBody);
    }
}
