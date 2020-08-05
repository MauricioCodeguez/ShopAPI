using Shop.Shared.Commands;

namespace Shop.Domain.Commands.Outputs
{
    public class CreateProductCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public CreateProductCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}