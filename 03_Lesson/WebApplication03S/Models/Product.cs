namespace WebApplication03S.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public int? Cost { get; set; }
        public int? GroupId { get; set; }

        public virtual Group? Group { get; set; } = null!;
        public virtual List<Store> Stores { get; set; } = null!;
        



    }
}
