using System.Collections.Generic;
using Newtonsoft.Json;

namespace IMDB.Domain.DTOs
{
    public class MoviesApiResponse
    {
        [JsonProperty("results")]
        public List<MovieDto> Results { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("dates")]
        public DatesDto Dates { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
