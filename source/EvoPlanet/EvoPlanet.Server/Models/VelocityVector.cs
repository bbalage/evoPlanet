using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class VelocityVector
    {
        [JsonPropertyName("VX")]
        public double VX { get; set; }

        [JsonPropertyName("VY")]
        public double VY { get; set; }
    }
}
