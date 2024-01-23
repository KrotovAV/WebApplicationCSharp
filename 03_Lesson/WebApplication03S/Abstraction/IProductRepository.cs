using WebApplication03S.Models.DTO;

namespace WebApplication03S.Abstraction
{
    public interface IProductRepository
    {
        public IEnumerable<GroupDto> GetGroups();
        public int AddGroup(GroupDto group);
        public bool DeleteGroup(int id);


        public IEnumerable<ProductDto> GetProducts();
        public int AddProduct(ProductDto product);
        public bool DeleteProduct(int id);

        public IEnumerable<StoreDto> GetStores();
        public int AddStore(StoreDto store);
        public bool DeleteStore(int id);

        public string GetProductsCSV();
        public string GetСacheStatCSV();


    }
    
}
