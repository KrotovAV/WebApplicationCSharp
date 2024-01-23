using AutoMapper;
using WebApplication03HW3.Models;
using WebApplication03HW3.Models.DTO;

namespace WebApplication03HW3.Repo
{
    public class MappingProFile : Profile
    {
        public MappingProFile()
        {
            CreateMap<Store, StoreDto>(MemberList.Destination).ReverseMap();
        }
    }
}
