using FluentValidator;
using FluentValidator.Validation;
using Shop.Shared.Commands;

namespace Shop.Domain.Commands.Inputs
{
    public class CreateProductCommand : Notifiable, ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public bool IsValid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(Name, 3, nameof(Name), "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Name, 150, nameof(Name), "O nome deve conter no máximo 150 caracteres")
                .HasMinLen(Description, 10, nameof(Description), "A descrição deve conter pelo menos 10 caracteres")
                .HasMaxLen(Description, 1000, nameof(Description), "A descrição deve conter no máximo 1000 caracteres"));

            return Valid;
        }
    }
}