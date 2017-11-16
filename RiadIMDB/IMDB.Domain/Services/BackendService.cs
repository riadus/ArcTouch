using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDB.Data;
using IMDB.Domain.Attributes;
using IMDB.Domain.DTOs;
using IMDB.Domain.Interfaces;

namespace IMDB.Domain.Services
{
    [RegisterInterfaceAsLazySingleton]
    public class BackendService : IBackendService
    {
        private readonly IApiClient _apiClient;
        private readonly IMovieMapper _movieMapper;
        private readonly IMapper<Language, string> _languageMapper;
        private readonly IFileStorageService _fileStorageService;
        private int _page;
        private IEnumerable<GenreDto> _genres; 
        public BackendService(IApiClient apiClient,
                              IMovieMapper movieMapper,
                              IMapper<Language, string> languageMapper,
                              IFileStorageService fileStorageService)
        {
            _page = 0;
            _apiClient = apiClient;
            _movieMapper = movieMapper;
            _languageMapper = languageMapper;
            _fileStorageService = fileStorageService;
        }

        public Task<IEnumerable<Movie>> GetMoreMovies(Language language)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetMovies(Language language)
        {
            var lang = _languageMapper.Map(language);
            var moviesResponse = await _apiClient.GetAsync<MoviesApiResponse>("movie/upcoming", lang).ConfigureAwait(false);
            if(_genres == null) {
                var genreResponse = await _apiClient.GetAsync<GenresApiResponse>("genre/movie/list", lang).ConfigureAwait(false);
                _genres = genreResponse.genres;
            }

            var movies = new List<Movie>();

            foreach (var movieDto in moviesResponse.Results)
            {
                var translations = await _apiClient.GetAsync<TranslationsApiResponse>($"movie/{movieDto.Id}/translations").ConfigureAwait(false);
                if (movieDto.PosterPath != null)
                {
                    await DownloadImageIfNeeded("Posters", movieDto.PosterPath);
                }
                if (movieDto.BackdropPath != null)
                {
                    await DownloadImageIfNeeded("Backdrops", movieDto.BackdropPath);
                }

                var movie = _movieMapper.Map(movieDto, _genres);
                movie.AvailableLanguages = translations.Translations.Select(translation => _languageMapper.MapBack(translation.Iso639_1)).ToList();
                movies.Add(movie);
            }

            _page = moviesResponse.Page;
            return movies;
        }

        private async Task DownloadImageIfNeeded(string folder, string filename)
        {
            if (!_fileStorageService.FileExists(folder, filename))
            {
                var poster = await _apiClient.GetImage(filename);
                _fileStorageService.SaveFile(poster, folder, filename);
            }
        }
    }
}
