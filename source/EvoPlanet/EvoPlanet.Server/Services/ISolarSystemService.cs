using EvoPlanet.Server.Models;

namespace EvoPlanet.Server.Services
{
    public interface ISolarSystemService
    {
        List<SolarSystem> GetAllSolarSystems();

        void SaveData(List<SolarSystem> solarSystems);

        void AddSolarSystem(SolarSystem newSolarSystem);

        void UpdateSolarSystem(string solarSystemId, SolarSystem updatedSolarSystem);

        void DeleteSolarSystem(string solarSystemId);

        Task<List<SolarSystem>> GetAllAsync();

        Task<SolarSystem> CreateAsync(SolarSystem sSystem);

        Task UpdateAsync(string solarSystemId, SolarSystem updatedSolarSystem);

        Task DeleteAsync(string solarSystemId);

        Task<SolarSystem> GetById(string id);
    }
}
