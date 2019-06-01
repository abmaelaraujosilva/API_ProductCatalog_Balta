using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;

namespace ProductCatalog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly StoreDataContext _context;
        public CategoryController(StoreDataContext context)
        {
            _context = context;
        }

        [Route("v1/categories")]
        [HttpGet]
        // Dica: Cache saiba quando usar
        // Duration = (minutos)
        // Como Funciona: No Cache a requizição não entra no Metodo, ele apenas retorna o valor que retornou quando iniciou o cache
        [ResponseCache(Duration = 60)]
        // [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        // Cache-Control: public,max-age=60
        public IEnumerable<Category> Get()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category Get(int id)
        {
            return _context.Categories.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("v1/categories/{id}/Products")]
        [HttpGet]
        public IEnumerable<Product> GetProducts(int id)
        {
            return _context.Products.AsNoTracking().Where(x => x.CategoryId == id).ToList();
        }

        [Route("v1/categories")]
        [HttpPost]
        public Category Post([FromBody]Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category;
        }

        [Route("v1/categories")]
        [HttpPut]
        //FromBody esta ai para dizer que o parametro 'Categoty' será recebido do corpo(Body - html) da requisição
        public Category Put([FromBody]Category category)
        {
            _context.Entry<Category>(category).State = EntityState.Modified;
            _context.SaveChanges();

            return category;
        }

        [Route("v1/categories")]
        [HttpDelete]
        public Category Delete([FromBody]Category category)
        {
            _context.Remove(category);
            _context.SaveChanges();

            return category;
        }
    }
}