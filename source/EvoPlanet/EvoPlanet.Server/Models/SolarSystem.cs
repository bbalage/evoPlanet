using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class SolarSystem
    {
        [JsonPropertyName("SolarSystemID")]
        public Guid SolarSystemID { get; set; } = Guid.Empty;

        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("CelestialBodies")]
        public List<CelestialBodyReference>? CelestialBodies { get; set;}
    }
}
