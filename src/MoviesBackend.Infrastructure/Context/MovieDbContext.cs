using MoviesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MoviesBackend.Infrastructure.Context
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }

        public DbSet<Movie> Moviees { get; set; }
    }
}
