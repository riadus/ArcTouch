using System;
using System.Collections.Generic;

namespace IMDB.Data
{
    public class Movie
    {
        public int Id { get; set; }

        public int VoteCount { get; set; }

        public bool IsVideo { get; set; }

        public double VoteAverage { get; set; }

        public string Title { get; set; }

        public double Popularity { get; set; }

        public string PosterPath { get; set; }

        public string OriginalLanguage { get; set; }

        public string OriginalTitle { get; set; }

        public List<string> Genres { get; set; }

        public string BackdropPath { get; set; }

        public bool IsAdult { get; set; }

        public string Overview { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}
