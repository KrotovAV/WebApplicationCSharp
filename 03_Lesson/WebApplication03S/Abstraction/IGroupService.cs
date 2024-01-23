using WebApplication03S.Models.DTO;

namespace WebApplication03S.Abstraction
{
    public interface IGroupService
    {
        IEnumerable<GroupDto> GetCategories();
        int AddCategory(GroupDto category);
    }
}
