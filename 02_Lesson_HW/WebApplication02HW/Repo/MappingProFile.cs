using AutoMapper;
using WebApplication02HW.Models;
using WebApplication02HW.Models.DTO;

namespace WebApplication02HW.Repo
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
