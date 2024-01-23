using AutoMapper;
using WebApplication03S.Models;
using WebApplication03S.Models.DTO;

namespace WebApplication03S.Repo
{
    public class MappingProFile : Profile
    {
        public MappingProFile()
        {
            CreateMap<Product, ProductDto>(MemberList.Destination).ReverseMap();
            CreateMap<Group, GroupDto>(MemberList.Destination).ReverseMap();
            CreateMap<Store, StoreDto>(MemberList.Destination).ReverseMap();
        }
    }
}
