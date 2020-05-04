using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class DeliveryManValidator: AbstractValidator<DeliveryMan>
    {
        public DeliveryManValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .NotEmpty()
                .OnAnyFailure(x => { throw new ArgumentException("Object invalid."); });

            RuleFor(x => x.name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe o nome do entregador.");
        }
    }
}
