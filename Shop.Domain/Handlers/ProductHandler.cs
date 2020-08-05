using FluentValidator;
using Shop.Domain.Commands.Inputs;
using Shop.Domain.Commands.Outputs;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using Shop.Shared.Commands;
using System;
using System.Threading.Tasks;

namespace Shop.Domain.Handlers
{
    public class ProductHandler : Notifiable, IProductHandler
    {
        readonly IProductRepository _productRepository;

        public ProductHandler(IProductRepository productRepository) => _productRepository = productRepository;

        public async Task<ICommandResult> DeleteProductHandler(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product.Id == Guid.Empty)
                return new CommandResult(false, "Produto não existe", null);

            await _productRepository.DeleteAsync(id);

            return new CommandResult(true, "Produto excluído com sucesso", new
            {
                product.Id,
                Name = product.ToString(),
                product.Description
            });
        }

        public async Task<ICommandResult> Handle(CreateProductCommand command)
        {
            if (!command.IsValid())
                AddNotifications(command.Notifications);

            if (await _productRepository.ExistsAsync(command.Name))
                AddNotification("Product", "Esse produto já existe");

            if (Invalid)
                return new CreateProductCommandResult(false, "Erro ao cadastrar o produto", Notifications);

            var product = new Product(command.Name, command.Description, command.Price);

            await _productRepository.SaveAsync(product);

            return new CreateProductCommandResult(true, "Produto cadastrado com sucesso", new
            {
                product.Id,
                Name = product.ToString(),
                product.Description,
                product.Price
            });
        }

        public async Task<ICommandResult> Handle(UpdateProductCommand command)
        {
            if (!command.IsValid())
                AddNotifications(command.Notifications);

            var product = new Product(command.Name, command.Description, command.Price);

            await _productRepository.UpdateAsync(product);

            return new UpdateProductCommandResult(true, "Produto atualizado com sucesso", new
            {
                product.Id,
                Name = product.ToString(),
                product.Description,
                product.Price
            });
        }
    }
}