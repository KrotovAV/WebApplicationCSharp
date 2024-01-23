using AutoMapper;
using WebApplication03S.Models;
using WebApplication03S.Models.DTO;

namespace WebApplication03S.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Store, StoreDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
        }
    }
}
