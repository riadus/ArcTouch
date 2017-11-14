using System.Collections.Generic;
using IMDB.Data;
using IMDB.Domain.Dtos;

namespace IMDB.Domain.Interfaces
{
    public interface IMapper<T1, T2>
    {
        T2 Map(T1 source);
        T1 MapBack(T2 source);
    }

    public interface IMovieMapper
    {
        Movie Map(MovieDto source, IEnumerable<GenreDto> genreDtos);
    }
}
