namespace WebApplication02S.Models
{
    public class Group : BaseModel
    {
        public string? Description { get; set; }
        public virtual List<Product> Products{get; set;} = new List<Product> ();


    }
}
