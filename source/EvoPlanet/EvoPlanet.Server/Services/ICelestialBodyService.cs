using EvoPlanet.Server.Models;

namespace EvoPlanet.Server.Services
{
    public interface ICelestialBodyService
    {
        List<CelestialBody> GetAllCelestialBodies();

        void SaveData(List<CelestialBody> celestialBodies);

        void AddCelestialBody(CelestialBody newCelestialBody);

        void UpdateCelestialBody(Guid celestialBodyId, CelestialBody updatedCelestialBody);

        void DeleteCelestialBody(Guid celestialBodyId);

        Task<List<CelestialBody>> GetAllAsync();

        Task<CelestialBody> CreateAsync(CelestialBody cBody);

        Task UpdateAsync(Guid celestialBodyId, CelestialBody updatedCelestialBody);

        Task DeleteAsync(Guid celestialBodyId);
    }
}
