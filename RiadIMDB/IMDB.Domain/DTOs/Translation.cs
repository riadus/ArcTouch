using Newtonsoft.Json;

namespace IMDB.Domain.DTOs
{
    public class Translation
    {
        [JsonProperty("iso_639_1")]
        public string Iso639_1 { get; set; }
        [JsonProperty("iso_3166_1")]
        public string Iso3166_1 { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("english_name")]
        public string EnglishName { get; set; }
    }
}
