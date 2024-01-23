using static System.Net.WebRequestMethods;

namespace WebApplication03HW3.Stores
{
    public class StoreClient : IStoreClient
    {
        readonly HttpClient client = new HttpClient();
        public async Task<bool> Exists(int id)
        {
            using HttpResponseMessage responce = await 
                client.GetAsync($"https://localhost:7210/Product/check_stores?id={id.ToString()}");
            responce.EnsureSuccessStatusCode();

            string responceBody = await responce.Content.ReadAsStringAsync();
            if(responceBody == "true")
            {
                return true;
            }
            if (responceBody == "false")
            {
                return false;
            }
            throw new Exception("Unknoun response");
        }
    }
}
