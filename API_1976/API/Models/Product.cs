using System;

namespace API.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int IDCategory { get; set; }
        public Category Category { get; set; }
    }
}
