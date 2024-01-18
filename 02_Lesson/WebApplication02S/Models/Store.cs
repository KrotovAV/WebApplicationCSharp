namespace WebApplication02S.Models
{
    public class Store : BaseModel
    {      
        public virtual List<Product> Products { get; set; } = new List<Product>();
        public int Count { get; set; }
  
    }
}
