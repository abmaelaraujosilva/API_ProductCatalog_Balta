using API.Data;
using API.Models;
using API.ViewModels.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories
{
    public class ProductRepository
    {
        private readonly StoreDataContext _context;
        public ProductRepository(StoreDataContext context)
        {
            _context = context;
        }
        public IEnumerable<ListProductViewModel> Get()
        {
            return _context.Products
                .Include(x => x.Category)
                .Select(x => new ListProductViewModel
                {
                    ID = x.ID,
                    Title = x.Title,
                    Description = x.Description
                })
                .AsNoTracking()
                .ToList();
        }
        public Product Get(int ID)
        {
            return _context.Products.Find(ID);
        }
        public void Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Edit(Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
