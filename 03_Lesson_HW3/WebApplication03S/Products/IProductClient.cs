namespace WebApplication03HW3.Products
{
    public interface IProductClient
    {
        public Task<bool> Exists(int id);
    }
}
