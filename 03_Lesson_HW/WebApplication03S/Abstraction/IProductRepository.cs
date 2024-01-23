using WebApplication03HW.Models.DTO;

namespace WebApplication03HW.Abstraction
{
    public interface IProductRepository
    {
        public IEnumerable<GroupDto> GetGroups();
        public int AddGroup(GroupDto group);
        public bool DeleteGroup(int id);


        public IEnumerable<ProductDto> GetProducts();
        public int AddProduct(ProductDto product);
        public bool DeleteProduct(int id);
        public bool CheckProduct(int id);

    }
    
}
