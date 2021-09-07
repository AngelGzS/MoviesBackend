using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MoviesBackend.Application.DTOs;
using MoviesBackend.Application.DTOs.Movie;
using MoviesBackend.Application.Extensions;
using MoviesBackend.Application.Filters;
using MoviesBackend.Application.Interfaces;
using MoviesBackend.Domain.Entities;
using MoviesBackend.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MoviesBackend.Application.Services
{
    public class MoviesAppService : IMoviesAppService
    {
        private readonly IMovieRepository _MovieRepository;

        private readonly IMapper _mapper;

        public MoviesAppService(IMapper mapper, IMovieRepository MovieRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _MovieRepository = MovieRepository ?? throw new ArgumentNullException(nameof(MovieRepository));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _MovieRepository.Dispose();
        }

        #region Movie Methods

        public async Task<PaginatedList<GetMovieDto>> GetAllMovies(GetMoviesFilter filter)
        {
            filter ??= new GetMoviesFilter();
            var Movies = _MovieRepository
                .GetAll()
                .WhereIf(!string.IsNullOrEmpty(filter.Title), x => EF.Functions.Like(x.Title, $"%{filter.Title}%"))
                .WhereIf(!string.IsNullOrEmpty(filter.Overview), x => EF.Functions.Like(x.Overview, $"%{filter.Overview}%"));
                
            return await _mapper.ProjectTo<GetMovieDto>(Movies).ToPaginatedListAsync(
                filter.CurrentPage,
                filter.PageSize);
        }

        public async Task<GetMovieDto> GetMovieById(int id)
        {
            return _mapper.Map<GetMovieDto>(await _MovieRepository.GetById(id));
        }

        public async Task<GetMovieDto> CreateMovie(InsertMovieDto Movie)
        {
            var created = _MovieRepository.Create(_mapper.Map<Movie>(Movie));
            await _MovieRepository.SaveChangesAsync();
            return _mapper.Map<GetMovieDto>(created);
        }

        public async Task<GetMovieDto> UpdateMovie(int id, UpdateMovieDto updatedMovie)
        {
            var originalMovie = await _MovieRepository.GetById(id);
            if (originalMovie == null) return null;

            originalMovie.Title = updatedMovie.Title;
            originalMovie.Overview = updatedMovie.Overview;
            originalMovie.ReleaseDate = updatedMovie.ReleaseDate;
            _MovieRepository.Update(originalMovie);
            await _MovieRepository.SaveChangesAsync();
            return _mapper.Map<GetMovieDto>(originalMovie);
        }

        public async Task<bool> DeleteMovie(int id)
        {
           await _MovieRepository.Delete(id);
           return await _MovieRepository.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
