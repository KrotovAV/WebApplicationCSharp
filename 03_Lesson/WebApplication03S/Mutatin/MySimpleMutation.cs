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
    }
}
