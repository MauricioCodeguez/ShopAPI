using Shop.Domain.Entities;
using Shop.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<bool> ExistsAsync(string name);
        Task SaveAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<ListProductQuery>> GetAllAsync();
        Task<GetProductQuery> GetByIdAsync(Guid id);
    }
}