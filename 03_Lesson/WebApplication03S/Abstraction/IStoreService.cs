using WebApplication03S.Models.DTO;

namespace WebApplication03S.Abstraction
{
    public interface IStoreService
    {
        IEnumerable<StoreDto> GetStores();
        int AddStore(StoreDto storage);
    }
}
