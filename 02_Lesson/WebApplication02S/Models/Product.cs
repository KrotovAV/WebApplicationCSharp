namespace WebApplication02S.Models
{
    public class Product : BaseModel
    {
        public string Description { get; set; } = null!;  
        public int GroupId { get; set; }
        public virtual Group Group { get; set; } = null!;
        public int Cost { get; set; }
        public virtual List<Store> Stores { get; set; } = null!;


    }
}
