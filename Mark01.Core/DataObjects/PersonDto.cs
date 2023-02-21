using Newtonsoft.Json;

namespace Mark01.Core.DataObjects
{
    public class PersonDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [JsonProperty("Email")]
        public string Email { get; set; } = null!;

        [JsonProperty("Type")]
        public string Type { get; set; } = null!;
    }
}
