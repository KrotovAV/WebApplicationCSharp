using WebApplication02HW.Models;

namespace WebApplication02HW.Models
{
    public class Store : BaseModel
    {
        public virtual List<Product>? Products { get; set; }
        public int Count { get; set; }

    }
}
