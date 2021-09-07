using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesBackend.Application.DTOs;
using MoviesBackend.Application.DTOs.Movie;
using MoviesBackend.Application.Filters;

namespace MoviesBackend.Application.Interfaces
{
    public interface IMoviesAppService : IDisposable
    {
        #region Movies Methods

        public Task<PaginatedList<GetMovieDto>> GetAllMovies(GetMoviesFilter filter);

        public Task<GetMovieDto> GetMovieById(int id);

        public Task<GetMovieDto> CreateMovie(InsertMovieDto Movie);

        public Task<GetMovieDto> UpdateMovie(int id, UpdateMovieDto updatedMovie);

        public Task<bool> DeleteMovie(int id);

        #endregion
    }
}