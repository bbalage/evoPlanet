using EvoPlanet.Server.Models;

namespace EvoPlanet.Server.Services
{
    public interface ICelestialBodyService
    {
        List<CelestialBodyDTO> GetAllCelestialBodies();

        void SaveData(List<CelestialBodyDTO> celestialBodies);

        void AddCelestialBody(CelestialBodyDTO newCelestialBody);

        void UpdateCelestialBody(int celestialBodyId, CelestialBodyDTO updatedCelestialBody);

        void DeleteCelestialBody(int celestialBodyId);

        public Task<List<CelestialBodyDTO>> GetAllAsync();

        public Task<CelestialBodyDTO> CreateAsync(CelestialBodyDTO cBody);
    }
}
