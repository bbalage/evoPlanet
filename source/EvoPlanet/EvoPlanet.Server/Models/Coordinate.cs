using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class Coordinate
    {
        [JsonPropertyName("PX")]
        public double PX { get; set; }

        [JsonPropertyName("PY")]
        public double PY { get; set; }
    }
}
