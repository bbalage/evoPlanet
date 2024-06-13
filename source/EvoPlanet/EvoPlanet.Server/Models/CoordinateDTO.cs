using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class CoordinateDTO
    {
        [JsonPropertyName("PX")]
        public double PX { get; set; }

        [JsonPropertyName("PY")]
        public double PY { get; set; }
    }
}
