using System;

namespace MoviesBackend.Application.Filters
{
    public class GetMoviesFilter : PaginationInfoFilter
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
