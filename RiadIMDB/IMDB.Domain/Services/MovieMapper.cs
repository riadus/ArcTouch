using System;
using System.Collections.Generic;
using System.Linq;
using IMDB.Data;
using IMDB.Domain.Attributes;
using IMDB.Domain.DTOs;
using IMDB.Domain.Interfaces;

namespace IMDB.Domain.Services
{
    [RegisterInterfaceAsLazySingleton]
    public class MovieMapper : IMovieMapper
    {
        private Movie Map(MovieDto source)
        {
            return new Movie
            {
                Id = source.Id,
                BackdropPath = source.BackdropPath,
                IsAdult = source.IsAdult,
                IsVideo = source.IsVideo,
                OriginalLanguage = source.OriginalLanguage,
                OriginalTitle = source.OriginalTitle,
                Overview = source.Overview,
                Popularity = source.Popularity,
                PosterPath = source.PosterPath,
                ReleaseDate = DateTime.Parse(source.ReleaseDate),
                Title = source.Title,
                VoteAverage = source.VoteAverage,
                VoteCount = source.VoteCount
            };
        }

        public Movie Map(MovieDto source, IEnumerable<GenreDto> genreDtos)
        {
            var movie = Map(source);
            movie.Genres = source.GenreIds.Select(genre => genreDtos.First(dto => dto.Id == genre).Name).ToList();
            return movie;
        }
    }
}
