﻿namespace WebApplication03S.Models.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public int Cost { get; set; }
        public int GroupId { get; set; }
    }
}
