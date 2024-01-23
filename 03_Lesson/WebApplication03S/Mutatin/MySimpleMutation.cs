using WebApplication03S.Abstraction;
using WebApplication03S.Models.DTO;

namespace WebApplication03S.Mutatin
{
    public class MySimpleMutation
    {
        public int AddProduct(ProductDto product, [Service] IProductService service)
        {
            var id = service.AddProduct(product);
            return id;
        }
        public int AddGroup(GroupDto group, [Service] IGroupService service)
        {
            var id = service.AddGroup(group);
            return id;
        }
        public int AddStore(StoreDto store, [Service] IStoreService service)
        {
            var id = service.AddStore(store);
            return id;
        }
    }
}
