namespace WebApplication02HW.Models
{
    public class Product : BaseModel
    {
        
        public virtual Group Group { get; set; } = null!;
        public int Cost { get; set; }
        public virtual List<Store> Stores { get; set; } = null!;
        public int GroupId { get; set; }



    }
}
