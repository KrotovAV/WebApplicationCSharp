using WebApplication03HW3.Models.DTO;

namespace WebApplication03HW3.Abstraction
{
    public interface IProdInStoreRepository
    {

        public IEnumerable<ProdInStoreDto> GetRecords();
        public int AddRecord(ProdInStoreDto record);
        public bool DeleteRecord(int id);

        public bool OrderProdFromStore(int prodId, int storeId, int count);
    }
}
