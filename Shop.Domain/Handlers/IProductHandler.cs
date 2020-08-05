using Shop.Domain.Commands.Inputs;
using Shop.Shared.Commands;
using System;
using System.Threading.Tasks;

namespace Shop.Domain.Handlers
{
    public interface IProductHandler : 
        ICommandHandler<CreateProductCommand>,
        ICommandHandler<UpdateProductCommand>
    {
        Task<ICommandResult> DeleteProductHandler(Guid id);
    }
}