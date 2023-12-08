﻿namespace ThucTap.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public required string Category { get; set; }
        public int ProductId { get; internal set; }
    }
}

