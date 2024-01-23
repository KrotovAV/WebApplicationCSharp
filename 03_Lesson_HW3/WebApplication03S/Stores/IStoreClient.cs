namespace WebApplication03HW3.Stores
{
    public interface IStoreClient
    {
        public Task<bool> Exists(int id);
    }
}
