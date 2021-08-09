using BookStore.ProductService.Context;
using BookStore.ProductService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ProductService.Persistence
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext productContext;

        public ProductRepository(ProductContext _productContext)
        {
            productContext = _productContext;
        }
        public void Add(Product product)
        {
            productContext.Add(product);
            productContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return productContext.Products.ToList();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await productContext.Products.ToListAsync();
        }

        public Product GetBy(Guid id)
        {
            return productContext.Find<Product>(id);
        }

        public void Remove(Guid id)
        {
            var product = GetBy(id);
            productContext.Remove(product);
        }

        public void Update(Product product)
        {
            productContext.Update(product);
        }

    }
}
