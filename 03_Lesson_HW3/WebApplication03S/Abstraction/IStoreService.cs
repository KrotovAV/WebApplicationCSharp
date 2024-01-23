using WebApplication03HW3.Models.DTO;

namespace WebApplication03HW3.Abstraction
{
    public interface IStoreService
    {
        IEnumerable<StoreDto> GetStores();
        int AddStore(StoreDto storage);
    }
}
