using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesBackend.Domain.Core.Entities
{
    public abstract class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}
