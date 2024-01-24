using AutoMapper;
using WebApplication03HW3.Models;
using WebApplication03HW3.Models.DTO;

namespace WebApplication03HW3.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //CreateMap<Store, StoreDto>().ReverseMap();
            CreateMap <ProdInStore, ProdInStoreDto>().ReverseMap();
        }
    }
}
