using BookStore.ProductService.Models;
using BookStore.ProductService.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult get()
        {
            var productvm = _productRepository.GetAll().Select(
                product => new ProductViewModel
                {
                    CategoryId = product.CategoryId,
                    CategoryDescription = product.Category.Description,
                    CategoryName = product.Category.Name,
                    ProductDescription = product.Description,
                    ProductId = product.Id,
                    ProductImage = product.Image,
                    ProductName = product.Name,
                    ProductPrice = product.Price
                });

            return new OkObjectResult(productvm);
        }
    }
}
