using EvoPlanet.Server.Models;

namespace EvoPlanet.Server.Services
{
    public interface ISolarSystemService
    {
        List<SolarSystemDTO> GetAllSolarSystems();

        void SaveData(List<SolarSystemDTO> solarSystems);

        void AddSolarSystem(SolarSystemDTO newSolarSystem);

        void UpdateSolarSystem(int solarSystemId, SolarSystemDTO updatedSolarSystem);

        void DeleteSolarSystem(int solarSystemId);

        public Task<List<SolarSystemDTO>> GetAllAsync();

        public Task<SolarSystemDTO> CreateAsync(SolarSystemDTO sSystem);
    }
}
