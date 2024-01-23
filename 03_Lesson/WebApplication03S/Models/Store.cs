﻿using WebApplication03S.Models;

namespace WebApplication03S.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public int Count { get; set; }


        public virtual List<Product>? Products { get; set; }
        

    }
}
