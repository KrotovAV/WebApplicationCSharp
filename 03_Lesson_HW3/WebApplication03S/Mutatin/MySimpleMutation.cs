using WebApplication03HW3.Abstraction;
using WebApplication03HW3.Models.DTO;

namespace WebApplication03HW3.Mutatin
{
    public class MySimpleMutation
    {

        public int AddStore(StoreDto store, [Service] IStoreService service)
        {
            var id = service.AddStore(store);
            return id;
        }
    }
}
