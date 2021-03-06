using MoviesBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MoviesBackend.Infrastructure.Migrations;
using System;
using System.Collections.Generic;

namespace MoviesBackend.Infrastructure.Context
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                    .Property(b => b.Id)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn(seed: 10, increment: 1);

            SeedMovies(modelBuilder);
        }


        private static void SeedMovies(ModelBuilder builder)
        {

            IEnumerable<Movie> data = new Movie[] { new Movie
                {
                    Id = 1,
                    Title = "The Godfather",
                    Overview = "The story spans the years from 1945 to 1955 and chronicles the fictional Italian-American Corleone crime family. When organized crime family patriarch Vito Corleone barely survives an attempt on his life, his youngest son, Michael, steps in to take care of the would-be killers, launching a campaign of bloody revenge.",
                    ReleaseDate = new DateTime(1972, 3, 15)
                },
                new Movie
                {
                    Id = 2,
                    Title = "Schindler's List",
                    Overview = "Jack is a young boy of 5 years old who has lived all his life in one room. He believes everything within it are the only real things in the world. But what will happen when his Ma suddenly tells him that there are other things outside of Room?",
                    ReleaseDate = new DateTime(2015, 10, 16)
                },
                new Movie
                {
                    Id = 3,
                    Title = "Fight Club",
                    Overview = "A burger-loving hit man, his philosophical partner, a drug-addled gangster's moll and a washed-up boxer converge in this sprawling, comedic crime caper. Their adventures unfurl in three stories that ingeniously trip back and forth in time.",
                    ReleaseDate = new DateTime(1994, 10, 14)
                },
                new Movie
                {
                    Id = 4,
                    Title = "Forrest Gump",
                    Overview = "A man with a low IQ has accomplished great things in his life and been present during significant historic events - in each case, far exceeding what anyone imagined he could do. Yet, despite all the things he has attained, his one true love eludes him. 'Forrest Gump' is the story of a man who rose above his challenges, and who proved that determination, courage, and love are more important than ability.",
                    ReleaseDate = new DateTime(1994, 7, 6)
                }
            };

            builder.Entity<Movie>().HasData(data);

        }
    }
}
