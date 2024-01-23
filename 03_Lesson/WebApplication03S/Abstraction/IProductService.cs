using WebApplication03S.Models.DTO;

namespace WebApplication03S.Abstraction
{
   
   public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();
        int AddProduct(ProductDto product);
    }
}
