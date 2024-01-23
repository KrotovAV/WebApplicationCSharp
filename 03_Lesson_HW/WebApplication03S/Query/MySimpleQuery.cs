using WebApplication03HW.Abstraction;
using WebApplication03HW.Models.DTO;

namespace WebApplication03HW.Query
{
    public class MySimpleQuery
    {
        public IEnumerable<ProductDto> GetProducts([Service] IProductService service) => service.GetProducts();
        public IEnumerable<GroupDto> GetCategories([Service] IGroupService service) => service.GetCategories();
    }
}
