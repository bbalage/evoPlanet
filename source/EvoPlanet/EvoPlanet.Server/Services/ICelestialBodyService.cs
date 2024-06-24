using EvoPlanet.Server.Models;

namespace EvoPlanet.Server.Services
{
    public interface ICelestialBodyService
    {
        List<CelestialBody> GetAllCelestialBodies();

        void SaveData(List<CelestialBody> celestialBodies);

        void AddCelestialBody(CelestialBody newCelestialBody);

        void UpdateCelestialBody(string celestialBodyId, CelestialBody updatedCelestialBody);

        void DeleteCelestialBody(string celestialBodyId);

        Task<List<CelestialBody>> GetAllAsync();

        Task<CelestialBody> CreateAsync(CelestialBody cBody);

        Task UpdateAsync(string celestialBodyId, CelestialBody updatedCelestialBody);

        Task DeleteAsync(string celestialBodyId);
    }
}
