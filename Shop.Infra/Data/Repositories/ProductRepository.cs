using Dapper;
using Shop.Domain.Context;
using Shop.Domain.Entities;
using Shop.Domain.Queries;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        readonly IDbContext _context;

        public ProductRepository(IDbContext context) => _context = context;

        public async Task DeleteAsync(Guid id)
            => await _context.Connection.ExecuteAsync("DELETE FROM Product WHERE Id = @Id", new { Id = id });

        public async Task<bool> ExistsAsync(string name)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" SELECT 1 ");
            sql.AppendLine("   FROM Product ");
            sql.AppendLine("  WHERE Name = @Name ");

            return await _context.Connection.ExecuteScalarAsync<bool>(sql.ToString(), new { Name = name });
        }

        public async Task<IEnumerable<ListProductQuery>> GetAllAsync()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" SELECT Id, ");
            sql.AppendLine("        Name, ");
            sql.AppendLine("        Description, ");
            sql.AppendLine("        Price, ");
            sql.AppendLine("        Updated ");
            sql.AppendLine("   FROM Product ");

            return await _context.Connection.QueryAsync<ListProductQuery>(sql.ToString());
        }

        public async Task<GetProductQuery> GetByIdAsync(Guid id)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" SELECT Id, ");
            sql.AppendLine("        Name, ");
            sql.AppendLine("        Description, ");
            sql.AppendLine("        Price, ");
            sql.AppendLine("        Updated ");
            sql.AppendLine("   FROM Product ");
            sql.AppendLine("  WHERE Id = @Id ");

            return await _context.Connection.QueryFirstAsync<GetProductQuery>(sql.ToString(), new { Id = id });
        }

        public async Task SaveAsync(Product product)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" INSERT INTO Product ( ");
            sql.AppendLine("        Id, ");
            sql.AppendLine("        Name, ");
            sql.AppendLine("        Description, ");
            sql.AppendLine("        Price, ");
            sql.AppendLine("        Updated ");
            sql.AppendLine(" ) VALUES ( ");
            sql.AppendLine("        @Id, ");
            sql.AppendLine("        @Name, ");
            sql.AppendLine("        @Description, ");
            sql.AppendLine("        @Price, ");
            sql.AppendLine("        GETDATE() ");
            sql.AppendLine(" ) ");

            await _context.Connection.ExecuteAsync(sql.ToString(), new
            {
                product.Id,
                product.Name,
                product.Description,
                product.Price
            });
        }

        public async Task UpdateAsync(Product product)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" UPDATE Product ");
            sql.AppendLine("    SET Name = @Name, ");
            sql.AppendLine("        Description = @Description, ");
            sql.AppendLine("        Price = @Price, ");
            sql.AppendLine("        Updated = GETDATE() ");
            sql.AppendLine("  WHERE Id = @Id ");

            await _context.Connection.ExecuteAsync(sql.ToString(), new
            {
                product.Id,
                product.Name,
                product.Description,
                product.Price
            });
        }
    }
}