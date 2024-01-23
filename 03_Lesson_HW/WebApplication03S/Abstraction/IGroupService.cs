using WebApplication03HW.Models.DTO;

namespace WebApplication03HW.Abstraction
{
    public interface IGroupService
    {
        IEnumerable<GroupDto> GetCategories();
        int AddCategory(GroupDto category);
    }
}
