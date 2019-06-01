using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.Repositories;
using ProductCatalog.ViewModels;
using ProductCatalog.ViewModels.ProductViewModels;

namespace ProductCatalog.Controllers
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
        public Product Get(int id)
        {
            return _repository.Get(id);
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
            product.CategoryId = model.CategoryId;
            product.Description = model.Description;
            product.CreateDate = DateTime.Now; //Nunca recebe essa informação da tela
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now; //Nunca recebe essa informação da tela
            product.Price = model.Price;
            product.Quantity = model.Quantity;

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
                    Mensage = "Não foi possível cadastrar o produto",
                    Data = model.Notifications
                };

            var product = _repository.Get(model.Id);
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.Description = model.Description;
            product.CreateDate = DateTime.Now; //Nunca recebe essa informação da tela
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now; //Nunca recebe essa informação da tela
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _repository.Update(product);

            return new ResultViewModel
            {
                Success = true,
                Mensage = "Produto cadastrado com sucesso!",
                Data = product
            };
        }
    }
}