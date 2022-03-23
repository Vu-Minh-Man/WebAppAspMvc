using AutoMapper;
using WebAppAspMvc.Models;
using WebAppAspMvc.Dtos;

namespace WebAppAspMvc.AutoMapperProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.GenreDto, opts => opts.MapFrom(src => src.Genre));
                
            //CreateMap<Genre, MovieDto>();
            CreateMap<MovieDto, Movie>()
                .ForMember(dest => dest.Genre, opts => opts.MapFrom(src => src.GenreDto));
        }
    }
}
