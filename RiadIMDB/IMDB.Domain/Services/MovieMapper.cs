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
        private readonly IMapper<Language, string> _languageMapper;
        public MovieMapper(IMapper<Language, string> languageMapper)
        {
            _languageMapper = languageMapper;
        }

        private Movie Map(MovieDto source)
        {
            return new Movie
            {
                Id = source.Id,
                BackdropPath = source.BackdropPath,
                IsAdult = source.IsAdult,
                IsVideo = source.IsVideo,
                OriginalLanguage = _languageMapper.MapBack(source.OriginalLanguage),
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
            movie.Genres = source.GenreIds.Select(genre => genreDtos.FirstOrDefault(dto => dto.Id == genre)?.Name).ToList();
            return movie;
        }

        public Movie Map(MovieDetailDto source, IEnumerable<GenreDto> genreDtos)
        {
            var movie = Map(source);
            movie.Genres = genreDtos.Select(x => x.Name).ToList();
            return movie;
        }
    }
}
