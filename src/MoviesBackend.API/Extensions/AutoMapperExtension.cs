using System;
using AutoMapper;
using MoviesBackend.Application.MappingProfiles;
using Microsoft.Extensions.DependencyInjection;

namespace MoviesBackend.Api.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
