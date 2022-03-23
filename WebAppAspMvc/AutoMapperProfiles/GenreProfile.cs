using AutoMapper;
using WebAppAspMvc.Models;
using WebAppAspMvc.Dtos;

namespace WebAppAspMvc.AutoMapperProfiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();
        }
    }
}
