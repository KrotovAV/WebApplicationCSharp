using AutoMapper;
using WebApplication03HW.Models;
using WebApplication03HW.Models.DTO;

namespace WebApplication03HW.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
        }
    }
}
