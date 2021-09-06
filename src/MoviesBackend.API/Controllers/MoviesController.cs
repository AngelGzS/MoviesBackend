using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MoviesBackend.Application.DTOs.Movie;
using MoviesBackend.Application.Filters;
using MoviesBackend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MoviesBackend.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMoviesAppService _movieAppService;

        public MovieController(IMoviesAppService heroAppService)
        {
            _movieAppService = heroAppService;
        }


        /// <summary>
        /// Returns all movies in the database
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<GetMovieDto>>> GetMovies([FromQuery] GetMoviesFilter filter)
        {
            return Ok(await _movieAppService.GetAllMovies(filter));
        }


        /// <summary>
        /// Get one movie by id from the database
        /// </summary>
        /// <param name="id">The movie's ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(GetMovieDto), 200)]
        public async Task<ActionResult<GetMovieDto>> GetMovieById(Guid id)
        {
            var movie = await _movieAppService.GetMovieById(id);
            if (movie == null) return NotFound();
            return Ok(movie);
        }

        /// <summary>
        /// Insert one movie in the database
        /// </summary>
        /// <param name="dto">The movie information</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GetMovieDto>> Create([FromBody] InsertMovieDto dto)
        {
            var newMovie = await _movieAppService.CreateMovie(dto);
            return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.Id }, newMovie);

        }

        /// <summary>
        /// Update a movie from the database
        /// </summary>
        /// <param name="id">The movie's ID</param>
        /// <param name="dto">The update object</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<GetMovieDto>> Update(Guid id, [FromBody] UpdateMovieDto dto)
        {

            var updatedMovie = await _movieAppService.UpdateMovie(id, dto);

            if (updatedMovie == null) return NotFound();

            return NoContent();
        }


        /// <summary>
        /// Delete a movie from the database
        /// </summary>
        /// <param name="id">The movie's ID</param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {

            var deleted = await _movieAppService.DeleteMovie(id);
            if (deleted) return NoContent();
            return NotFound();

        }
    }
}
