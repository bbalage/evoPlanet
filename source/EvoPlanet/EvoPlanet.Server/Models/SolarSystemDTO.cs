using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class SolarSystemDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid SolarSystemID { get; set; } = Guid.Empty;

        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("CelestialBodies")]
        public CelestialBodyDTO? CelestialBodies { get; set; }
    }
}
