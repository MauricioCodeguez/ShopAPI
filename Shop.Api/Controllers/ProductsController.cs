using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Commands.Inputs;
using Shop.Domain.Commands.Outputs;
using Shop.Domain.Handlers;
using Shop.Domain.Queries;
using Shop.Domain.Repositories;
using Shop.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductRepository _productRepository;
        readonly IProductHandler _productHandler;

        public ProductsController(
            IProductRepository productRepository,
            IProductHandler productHandler)
        {
            _productRepository = productRepository;
            _productHandler = productHandler;
        }

        [HttpGet]
        [Route("v1/products")]
        public async Task<IEnumerable<ListProductQuery>> Get()
            => await _productRepository.GetAllAsync();

        [HttpGet]
        [Route("v1/products/{id}")]
        public async Task<GetProductQuery> GetById(Guid id)
            => await _productRepository.GetByIdAsync(id);

        [HttpPost]
        [Route("v1/products")]
        public async Task<ICommandResult> Post([FromBody] CreateProductCommand product)
            => (CreateProductCommandResult)await _productHandler.Handle(product);

        [HttpPut]
        [Route("v1/products")]
        public async Task<ICommandResult> Put([FromBody] UpdateProductCommand product)
            => (UpdateProductCommandResult)await _productHandler.Handle(product);

        [HttpDelete]
        [Route("v1/products/{id}")]
        public async Task<ICommandResult> Delete(Guid id)
            => (CommandResult)await _productHandler.DeleteProductHandler(id);
    }
}
