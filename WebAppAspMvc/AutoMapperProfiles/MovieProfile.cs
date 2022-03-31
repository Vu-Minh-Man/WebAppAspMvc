using AutoMapper;
using WebAppAspMvc.Models;
using WebAppAspMvc.Dtos;
using WebAppAspMvc.ViewModels;

namespace WebAppAspMvc.AutoMapperProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>()
                .ForMember(dest => dest.GenreDto, opt => opt.MapFrom(src => src.Genre));
                
            //CreateMap<Genre, MovieDto>();
            CreateMap<MovieDto, Movie>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.GenreDto));

            CreateMap<MovieEditViewModel, MovieDto>();
                //.ForMember(dest => dest.GenreDto, opt => opt.MapFrom(src => src.Genres.ElementAt(src.GenreId)));

        }
    }
}
