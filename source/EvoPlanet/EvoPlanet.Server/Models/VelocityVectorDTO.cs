using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class VelocityVectorDTO
    {
        [JsonPropertyName("VX")]
        public double VX { get; set; }

        [JsonPropertyName("VY")]
        public double VY { get; set; }
    }
}
