using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class SolarSystem
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("CelestialBodies")]
        public List<CelestialBodyReference>? CelestialBodies { get; set;}
    }
}
