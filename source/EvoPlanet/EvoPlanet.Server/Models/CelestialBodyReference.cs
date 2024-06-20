using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class CelestialBodyReference
    {
        [JsonPropertyName("CelestialBodyID")]
        public Guid CelestialBodyID { get; set; } = Guid.Empty;

        [JsonPropertyName("Coordinate")]
        public Coordinate? Coordinate { get; set; }

        [JsonPropertyName("VelocityVector")]
        public VelocityVector? Velocity { get; set; }
    }
}
