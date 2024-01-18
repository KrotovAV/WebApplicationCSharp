using AutoMapper;
using WebApplication02S.Models;
using WebApplication02S.Models.DTO;
namespace WebApplication02S.Repo
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
