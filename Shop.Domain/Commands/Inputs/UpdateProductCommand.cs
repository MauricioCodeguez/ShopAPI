using FluentValidator;
using FluentValidator.Validation;
using Shop.Shared.Commands;
using System;

namespace Shop.Domain.Commands.Inputs
{
    public class UpdateProductCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public bool IsValid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasLen(Id.ToString(), 36, nameof(Id), "Id inválido")
                .HasMinLen(Name, 3, nameof(Name), "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(Name, 150, nameof(Name), "O nome deve conter no máximo 150 caracteres")
                .HasMinLen(Description, 10, nameof(Description), "A descrição deve conter pelo menos 10 caracteres")
                .HasMaxLen(Description, 1000, nameof(Description), "A descrição deve conter no máximo 1000 caracteres"));

            return Valid;
        }
    }
}