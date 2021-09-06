﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesBackend.Domain.Core.Entities
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
