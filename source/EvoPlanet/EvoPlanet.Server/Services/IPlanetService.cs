using EvoPlanet.Server.Models;

namespace EvoPlanet.Server.Services
{
    public interface IPlanetService
    {
        List<Planet> GetAllPlanets();

        void SaveData(List<Planet> planets);

        void AddPlanet(Planet newPlanet);

        void UpdatePlanet(string planetName, Planet updatedPlanet);

        void DeletePlanet(string planetName);
    }
}
