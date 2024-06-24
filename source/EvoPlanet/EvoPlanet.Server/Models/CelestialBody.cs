using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class CelestialBody
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? CelestialBodyID { get; set; } = string.Empty;

        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("Radius")]
        public double Radius { get; set; }

        [JsonPropertyName("Mass")]
        public double Mass { get; set; }
    }
}
