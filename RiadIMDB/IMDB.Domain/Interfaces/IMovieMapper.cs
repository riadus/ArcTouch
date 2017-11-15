using System.Collections.Generic;
using IMDB.Data;
using IMDB.Domain.Dtos;

namespace IMDB.Domain.Interfaces
{
    public interface IMovieMapper
    {
        Movie Map(MovieDto source, IEnumerable<GenreDto> genreDtos);
    }
}
