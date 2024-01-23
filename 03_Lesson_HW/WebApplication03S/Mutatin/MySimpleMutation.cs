using WebApplication03HW.Abstraction;
using WebApplication03HW.Models.DTO;

namespace WebApplication03HW.Mutatin
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
