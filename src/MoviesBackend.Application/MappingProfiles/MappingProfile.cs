using AutoMapper;
using MoviesBackend.Application.DTOs.Movie;
using MoviesBackend.Domain.Entities;

namespace MoviesBackend.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Movie Map
            CreateMap<Movie, GetMovieDto>().ReverseMap();
            CreateMap<InsertMovieDto, Movie>();
            CreateMap<UpdateMovieDto, Movie>();
        }
    }
}
