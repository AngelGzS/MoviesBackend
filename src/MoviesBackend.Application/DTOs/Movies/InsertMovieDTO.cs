using System;
using System.ComponentModel.DataAnnotations;


namespace MoviesBackend.Application.DTOs.Movie
{
    public class InsertMovieDto
    {
        [Required(ErrorMessage = "The movie title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The movie overview is required")]
        public string Overview { get; set; }
        
        public DateTime ReleaseDate { get; set; }
    }
}
