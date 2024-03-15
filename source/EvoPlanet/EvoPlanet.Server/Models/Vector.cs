using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class Vector
    {
        [JsonPropertyName("X")]
        private double x { get; set; } = 0;
        [JsonPropertyName("Y")]
        private double y { get; set; } = 0;
        public Vector(double X, double Y)
        {
            x = X;
            y = Y;
        }
    }
}
