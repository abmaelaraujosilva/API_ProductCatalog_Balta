using System.Collections.Generic;
using API.Models;
using API.Repositories;
using API.ViewModels;
using API.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository;
        public ProductController(ProductRepository repository)
        {
            _repository = repository;
        }
        [Route("v1/Products")]
        [HttpGet]
        public IEnumerable<ListProductViewModel> Get()
        {
            return _repository.Get();
        }
        [Route("v1/Products/{id}")]
        [HttpGet]
        public Product Get(int Id)
        {
            return _repository.Get(Id);
        }

        [Route("v1/Products")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditProductViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Mensage = "Não foi possível cadastrar o produto",
                    Data = model.Notifications
                };
            var product = new Product();
            product.Title = model.Title;
            product.IDCategory = model.IDCategory;
            product.Description = model.Description;
            product.Price = model.Price;

            _repository.Save(product);
            return new ResultViewModel
            {
                Success = true,
                Mensage = "Produto cadastrado com sucesso!",
                Data = product
            };
        }

        [Route("v1/Products")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditProductViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Mensage = "Não foi possível editar o produto",
                    Data = model.Notifications
                };
            var product = new Product();
            product.Title = model.Title;
            product.IDCategory = model.IDCategory;
            product.Description = model.Description;
            product.Price = model.Price;

            _repository.Edit(product);

            return new ResultViewModel
            {
                Success = true,
                Mensage = "Produto editado com sucesso!",
                Data = product
            };
        }
    }
}