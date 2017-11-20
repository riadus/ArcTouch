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
        private int _maxPage;
        private IEnumerable<GenreDto> _genres; 
        public BackendService(IApiClient apiClient,
                              IMovieMapper movieMapper,
                              IMapper<Language, string> languageMapper,
                              IFileStorageService fileStorageService)
        {
            _page = 1;
            _apiClient = apiClient;
            _movieMapper = movieMapper;
            _languageMapper = languageMapper;
            _fileStorageService = fileStorageService;
        }

        public async Task<IEnumerable<Movie>> GetMoreMovies(Language language)
        {
            if (_page == _maxPage)
            {
                return new List<Movie>();
            }
            return await GetMovies(language, _page).ConfigureAwait(false);
        }

        public Task<IEnumerable<Movie>> GetMovies(Language language)
        {
            return GetMovies(language, 1);
        }

        private async Task<IEnumerable<Movie>> GetMovies(Language language, int page)
        {
            var lang = _languageMapper.Map(language);
            var moviesResponse = await _apiClient.GetAsync<MoviesApiResponse>("movie/upcoming", lang, page).ConfigureAwait(false);
            if(_genres == null) {
                var genreResponse = await _apiClient.GetAsync<GenresApiResponse>("genre/movie/list", lang).ConfigureAwait(false);
                _genres = genreResponse?.genres ?? new List<GenreDto>();
            }

            var movies = new List<Movie>();

            foreach (var movieDto in moviesResponse.Results)
            {
                var translations = await _apiClient.GetAsync<TranslationsApiResponse>($"movie/{movieDto.Id}/translations").ConfigureAwait(false);
                if (movieDto.PosterPath != null)
                {
                    await DownloadImageIfNeeded("Posters", movieDto.PosterPath).ConfigureAwait(false);
                }
                if (movieDto.BackdropPath != null)
                {
                    await DownloadImageIfNeeded("Backdrops", movieDto.BackdropPath).ConfigureAwait(false);
                }

                var movie = _movieMapper.Map(movieDto, _genres);
                movie.AvailableLanguages = translations.Translations?.Select(translation => _languageMapper.MapBack(translation.Iso639_1)).ToList();
                movies.Add(movie);
            }

            _page = moviesResponse.Page + 1;
            _maxPage = moviesResponse.TotalPages;
            return movies;
        }

        public async Task<Movie> GetMovieDetail(int id, Language language)
        {
            var lang = _languageMapper.Map(language);
            var movieDto = await _apiClient.GetAsync<MovieDetailDto>($"movie/{id}", lang).ConfigureAwait(false);
            var movie = _movieMapper.Map(movieDto, movieDto.Genres);
            return movie;
        }

        private async Task DownloadImageIfNeeded(string folder, string filename)
        {
            if (!_fileStorageService.FileExists(folder, filename))
            {
                var poster = await _apiClient.GetImage(filename).ConfigureAwait(false);
                _fileStorageService.SaveFile(poster, folder, filename);
            }
        }
    }
}
