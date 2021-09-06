using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesBackend.Domain.Entities;
using MoviesBackend.Infrastructure.Context;
using MoviesBackend.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MovieRepository.Api.UnitTests
{
    public class MovieRepositoryTests
    {
        private MoviesDbContext CreateDbContext(string name)
        {
            var options = new DbContextOptionsBuilder<MoviesDbContext>()
            .UseInMemoryDatabase(name)
            .Options;
            return new MoviesDbContext(options);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(15)]
        public async Task GetAll_movies(int count)
        {

            using (var context = CreateDbContext($"GetAll_with_movies_{count}"))
            {
                for (var i = 0; i < count; i++) context.Set<Movie>().Add(new Movie());
                await context.SaveChangesAsync();
            }

            List<Movie> movies = null;
			
            using (var context = CreateDbContext($"GetAll_with_movies_{count}"))
            {
                var repository = new MoviesBackend.Infrastructure.Repositories.MovieRepository(context);
                movies = await repository.GetAll().ToListAsync();
            }
            

            movies.Should().NotBeNull();
            movies.Count.Should().Be(count);
        }

        [Fact]
        public async Task Create_Movie()
        {
            // Arrange
            int result;


            // Movie
            var movie = new Movie
            {
                Title = "Movie Title",
            };

            using (var context = CreateDbContext("Create_Movie"))
            {
                var repository = new MoviesBackend.Infrastructure.Repositories.MovieRepository(context);
                repository.Create(movie);
                result = await repository.SaveChangesAsync();
            }


            // Assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(1);
            // Simulate access from another context to verifiy that correct data was saved to database
            using (var context = CreateDbContext("Create_Movie"))
            {
                (await context.Moviees.CountAsync()).Should().Be(1);
                (await context.Moviees.FirstAsync()).Should().BeEquivalentTo(movie);
            }
        }


        [Fact]
        public void NullDbContext_Throws_ArgumentNullException()
        {
            var exception = Assert.Throws<ArgumentNullException>(() =>
            {
                new MoviesBackend.Infrastructure.Repositories.MovieRepository(null);
            });
            exception.Should().NotBeNull();
            exception.ParamName.Should().Be("dbContext");
        }
    }
}
