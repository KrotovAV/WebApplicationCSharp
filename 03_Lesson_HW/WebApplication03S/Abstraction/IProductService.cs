using WebApplication03HW.Models.DTO;

namespace WebApplication03HW.Abstraction
{
   
   public interface IProductService
    {
        IEnumerable<ProductDto> GetProducts();
        int AddProduct(ProductDto product);
    }
}
