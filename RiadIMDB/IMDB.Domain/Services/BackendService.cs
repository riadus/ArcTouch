using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB.Data;
using IMDB.Domain.Attributes;
using IMDB.Domain.Dtos;
using IMDB.Domain.Interfaces;

namespace IMDB.Domain.Services
{
    [RegisterInterfaceAsLazySingleton]
    public class BackendService : IBackendService
    {
        private readonly IApiClient _apiClient;
        private readonly IMovieMapper _movieMapper;
        private int _page;
        private IEnumerable<GenreDto> _genres; 
        public BackendService(IApiClient apiClient, IMovieMapper movieMapper)
        {
            _page = 0;
            _apiClient = apiClient;
            _movieMapper = movieMapper;
        }

        public Task<IEnumerable<Movie>> GetMoreMovies(string filmFilter)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMovies(string filmFilter)
        {
            var moviesResponse = await _apiClient.GetAsync<MoviesApiResponse>("movie/upcoming").ConfigureAwait(false);
            if(_genres == null) {
                var genreResponse = await _apiClient.GetAsync<GenresApiResponse>("genre/movie/list").ConfigureAwait(false);
                _genres = genreResponse.genres;
            }

            var movies = moviesResponse.Results.Select(movieDto => _movieMapper.Map(movieDto, _genres));
            _page = moviesResponse.Page;
            return movies;
        }
    }
}
