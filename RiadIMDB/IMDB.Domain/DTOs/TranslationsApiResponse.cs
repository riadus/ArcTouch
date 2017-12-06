using System.Collections.Generic;
using Newtonsoft.Json;

namespace IMDB.Domain.DTOs
{
    public class TranslationsApiResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("translations")]
        public List<Translation> Translations { get; set; }
    }
}
