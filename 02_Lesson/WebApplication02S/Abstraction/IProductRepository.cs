using WebApplication02S.Models.DTO;

namespace WebApplication02S.Abstraction
{
    public interface IProductRepository
    {
        public IEnumerable<ProductDto> GetProducts();
        public int AddProduct(ProductDto product);
        public bool DeleteProduct(int id);
        public bool AddProductCost(int id, int cost);
    }
}
