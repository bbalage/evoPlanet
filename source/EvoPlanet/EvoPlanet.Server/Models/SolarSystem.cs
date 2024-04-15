using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class SolarSystem
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("PX")]
        public double PX { get; set; }

        [JsonPropertyName("PY")]
        public double PY { get; set; }

        [JsonPropertyName("VX")]
        public double VX { get; set; }

        [JsonPropertyName("VY")]
        public double VY { get; set; }

        [JsonPropertyName("Radius")]
        public double Radius { get; set; }

        [JsonPropertyName("Mass")]
        public double Mass { get; set; }
    }
}
