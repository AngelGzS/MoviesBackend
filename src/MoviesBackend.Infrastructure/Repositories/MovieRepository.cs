using MoviesBackend.Domain.Entities;
using MoviesBackend.Domain.Repositories;
using MoviesBackend.Infrastructure.Context;

namespace MoviesBackend.Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MoviesDbContext dbContext) : base(dbContext) { }
    }
}

