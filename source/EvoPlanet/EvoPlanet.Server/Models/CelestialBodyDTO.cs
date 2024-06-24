using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class CelestialBodyDTO
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CelestialBodyID { get; set; } = string.Empty;

        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("Radius")]
        public double Radius { get; set; }

        [JsonPropertyName("Mass")]
        public double Mass { get; set; }

        [JsonPropertyName("Coordinate")]
        public Coordinate? Coordinate { get; set; }

        [JsonPropertyName("VelocityVector")]
        public VelocityVector? VelocityVector { get; set; }
    }
}
