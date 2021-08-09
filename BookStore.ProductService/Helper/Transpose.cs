using BookStore.ProductService.Context;
using BookStore.ProductService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.ProductService.Helper
{
    public static class Transpose
    {
        public static ProductViewModel ToViewModel()
        {
            return new ProductViewModel
            {
                CategoryId = product.CategoryId,
                CategoryDescription = product.Category.Description,
                CategoryName = product.Category.Name,
                ProductDescription = product.Description,
                ProductId = product.Id,
                ProductImage = product.Image,
                ProductName = product.Name,
                ProductPrice = product.Price
            };
        }
    }
}