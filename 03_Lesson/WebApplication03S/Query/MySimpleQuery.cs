using WebApplication03S.Abstraction;
using WebApplication03S.Models.DTO;

namespace WebApplication03S.Query
{
    public class MySimpleQuery
    {
        public IEnumerable<ProductDto> GetProducts([Service] IProductService service) => service.GetProducts();
        public IEnumerable<StoreDto> GetStorages([Service] IStoreService service) => service.GetStorages();
        public IEnumerable<GroupDto> GetCategories([Service] IGroupService service) => service.GetCategories();
    }
}
