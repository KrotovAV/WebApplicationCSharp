using WebApplication03S.Models.DTO;

namespace WebApplication03S.Abstraction
{
    public interface IGroupService
    {
        IEnumerable<GroupDto> GetGroups();
        int AddGroup(GroupDto group);
    }
}
