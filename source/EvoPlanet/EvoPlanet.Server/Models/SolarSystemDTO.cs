using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class SolarSystemDTO
    {
        [JsonPropertyName("SolarSystemID")]
        public int SolarSystemID { get; set; }

        [JsonPropertyName("Id")]
        public Guid Id { get; set; } = Guid.Empty;

        [JsonPropertyName("Name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("Coordinate")]
        public List<CoordinateDTO> Coordinate { get; set; } = new List<CoordinateDTO>();

        [JsonPropertyName("VelocityVector")]
        public List<VelocityVectorDTO> VelocityVector { get; set; } = new List<VelocityVectorDTO>();
    }
}
