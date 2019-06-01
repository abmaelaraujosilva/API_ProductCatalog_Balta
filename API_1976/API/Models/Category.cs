using System.Collections.Generic;

namespace API.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
