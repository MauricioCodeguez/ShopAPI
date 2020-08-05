using Shop.Domain.Entities;
using Shop.Domain.Queries;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Tests.Fakes
{
    public class FakeProductRepository : IProductRepository
    {
        private IList<Product> _products;

        public FakeProductRepository()
        {
            _products = new List<Product>
            {
                new Product("Produto 1", "Descrição 1", 100),
                new Product("Produto 2", "Descrição 2", 200),
                new Product("Produto 3", "Descrição 3", 300),
                new Product("Produto 4", "Descrição 4", 400),
                new Product("Produto 5", "Descrição 5", 500)
            };
        }

        public Task DeleteAsync(Guid id)
        {
            var product = _products.FirstOrDefault(a => a.Id == id);
            _products.Remove(product);
            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(string name)
        {
            var product = _products.FirstOrDefault(a => a.Name.Contains(name));
            return Task.FromResult(product != null);
        }

        public Task<IEnumerable<ListProductQuery>> GetAllAsync()
        {
            List<ListProductQuery> _result = new List<ListProductQuery>();

            foreach (var item in _products)
            {
                _result.Add(new ListProductQuery
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price
                });
            }

            return Task.FromResult((IEnumerable<ListProductQuery>)_result);
        }

        public Task<GetProductQuery> GetByIdAsync(Guid id)
        {
            var product = _products.FirstOrDefault(a => a.Id == id);

            if (product != null)
            {
                GetProductQuery result = new GetProductQuery
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                };

                return Task.FromResult(result);
            }

            return Task.FromResult(new GetProductQuery());
        }

        public Task SaveAsync(Product product)
        {
            if (product != null)
                _products.Add(product);

            return Task.CompletedTask;
        }

        public Task UpdateAsync(Product product)
        {
            if (product != null)
            {
                var item = _products.FirstOrDefault(a => a.Id == product.Id);

                if (item != null)
                    item.UpdateProduct(product.Name, product.Description, product.Price);
            }

            return Task.CompletedTask;
        }
    }
}
