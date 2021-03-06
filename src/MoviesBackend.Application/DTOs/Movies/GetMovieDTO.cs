using System;

namespace MoviesBackend.Application.DTOs.Movie
{
    public class GetMovieDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}