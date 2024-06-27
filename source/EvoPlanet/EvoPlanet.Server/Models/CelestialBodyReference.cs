using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class CelestialBodyReference
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CelestialBodyID { get; set; }

        [JsonPropertyName("Coordinate")]
        public Coordinate? Coordinate { get; set; }

        [JsonPropertyName("VelocityVector")]
        public VelocityVector? Velocity { get; set; }
    }
}
