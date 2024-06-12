using EvoPlanet.Server.Models;

namespace EvoPlanet.Server.Services
{
    public interface ISolarSystemService
    {
        List<SolarSystem> GetAllSolarSystems();

        void SaveData(List<SolarSystem> solarSystems);

        void AddSolarSystem(SolarSystem newSolarSystem);

        void UpdateSolarSystem(int solarSystemId, SolarSystem updatedSolarSystem);

        void DeleteSolarSystem(int solarSystemId);
    }
}
