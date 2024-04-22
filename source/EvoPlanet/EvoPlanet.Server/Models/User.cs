using System.Text.Json.Serialization;

namespace EvoPlanet.Server.Models
{
    public class User
    {
        [JsonPropertyName("UserId")]
        public int UserId { get; set; }

        [JsonPropertyName("UserName")]
        public string UserName { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }


        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}