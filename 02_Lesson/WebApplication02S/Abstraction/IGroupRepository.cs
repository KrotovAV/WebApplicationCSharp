using WebApplication02S.Models.DTO;

namespace WebApplication02S.Abstraction
{
    public interface IGroupRepository
    {
        public IEnumerable<GroupDto> GetGroups();
        public int AddGroup(GroupDto groupDto);

        public bool DeleteGroup(int id);


    }
}
