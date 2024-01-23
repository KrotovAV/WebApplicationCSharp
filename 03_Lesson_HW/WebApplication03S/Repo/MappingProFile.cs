using AutoMapper;
using WebApplication03HW.Models;
using WebApplication03HW.Models.DTO;

namespace WebApplication03HW.Repo
{
    public class MappingProFile : Profile
    {
        public MappingProFile()
        {
            CreateMap<Product, ProductDto>(MemberList.Destination).ReverseMap();
            CreateMap<Group, GroupDto>(MemberList.Destination).ReverseMap();

        }
    }
}
