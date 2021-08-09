using BookStore.ProductService.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.ProductService.Persistence
{
    public interface IProductRepository
    {
        void Add(Product product);
        IEnumerable<Product> GetAll();

        Product GetBy(Guid id);

        void Remove(Guid id);

        void Update(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
