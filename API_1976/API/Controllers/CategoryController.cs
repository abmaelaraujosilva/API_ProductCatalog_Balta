using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
    public class CategoryController : Controller
    {
        private readonly StoreDataContext _context;
        public CategoryController(StoreDataContext context)
        {
            _context = context;
        }

        [Route("v1/Categories")]
        [HttpGet]
        //[ResponseCache (Duration = 60)]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.AsNoTracking().ToList();
        }
        [Route("v1/Categories/{id}")]
        [HttpGet]
        public Category Get(int Id)
        {
            return _context.Categories.AsNoTracking().Where(x => x.ID == Id).FirstOrDefault();
        }

        [Route("v1/Categories/{id}/Product")]
        [HttpGet]
        public IEnumerable<Product> GetProducts(int Id)
        {
            return _context.Products.AsNoTracking().Where(x=>x.IDCategory == Id).ToList();
        }
        [Route("v1/Categories")]
        [HttpPost]
        public Category Post([FromBody]Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }
        [Route("v1/Categories")]
        [HttpPut]
        public Category Put([FromBody]Category category)
        {
            _context.Entry<Category>(category).State = EntityState.Modified;
            _context.SaveChanges();

            return category;
        }
    }
}