using System.Collections.Generic;

namespace SportsStore.Models
{
    public class FakeProductRepository 
    {
        public IEnumerable<Product> Products => new List<Product>
            {
                new Product { Name = "Football", Price = 25m },
                new Product { Name = "Surf board", Price = 179m },
                new Product { Name = "Running shoes", Price = 95m }
            };
        
    }
}
