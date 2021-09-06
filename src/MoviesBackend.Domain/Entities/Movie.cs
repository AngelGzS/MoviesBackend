using System;
using System.ComponentModel.DataAnnotations;
using MoviesBackend.Domain.Core.Entities;

namespace MoviesBackend.Domain.Entities
{
    public class Movie : Entity
    {
        [Required]
        public string Title { get; set; }
        public string Overview { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
