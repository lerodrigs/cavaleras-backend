using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class DeliveryManUpdateValidator: AbstractValidator<DeliveryMan>
    {
        public DeliveryManUpdateValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .NotEmpty()
                .OnAnyFailure(x => { throw new ArgumentException("Object invalid."); });

            RuleFor(x => x.id)
                .NotNull()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
