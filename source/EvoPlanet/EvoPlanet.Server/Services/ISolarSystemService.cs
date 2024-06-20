using EvoPlanet.Server.Models;

namespace EvoPlanet.Server.Services
{
    public interface ISolarSystemService
    {
        List<SolarSystem> GetAllSolarSystems();

        void SaveData(List<SolarSystem> solarSystems);

        void AddSolarSystem(SolarSystem newSolarSystem);

        void UpdateSolarSystem(Guid solarSystemId, SolarSystem updatedSolarSystem);

        void DeleteSolarSystem(Guid solarSystemId);

        Task<List<SolarSystem>> GetAllAsync();

        Task<SolarSystem> CreateAsync(SolarSystem sSystem);

        Task UpdateAsync(Guid solarSystemId, SolarSystem updatedSolarSystem);

        Task DeleteAsync(Guid solarSystemId);
    }
}
