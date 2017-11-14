using Newtonsoft.Json;

namespace IMDB.Domain.Dtos
{
    public class DatesDto
    {
        [JsonProperty("maximum")]
        public string Maximum { get; set; }

        [JsonProperty("minimum")]
        public string Minimum { get; set; }
    }
}
