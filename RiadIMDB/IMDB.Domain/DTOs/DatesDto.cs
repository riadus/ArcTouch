using Newtonsoft.Json;

namespace IMDB.Domain.DTOs
{
    public class DatesDto
    {
        [JsonProperty("maximum")]
        public string Maximum { get; set; }

        [JsonProperty("minimum")]
        public string Minimum { get; set; }
    }
}
