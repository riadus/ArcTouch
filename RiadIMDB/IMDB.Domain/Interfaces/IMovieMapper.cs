using System.Collections.Generic;
using IMDB.Data;
using IMDB.Domain.DTOs;

namespace IMDB.Domain.Interfaces
{
    public interface IMovieMapper
    {
        Movie Map(MovieDto source, IEnumerable<GenreDto> genreDtos);
    }
}
