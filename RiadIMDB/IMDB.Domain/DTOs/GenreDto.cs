using Newtonsoft.Json;

namespace IMDB.Domain.DTOs
{
    public class GenreDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
