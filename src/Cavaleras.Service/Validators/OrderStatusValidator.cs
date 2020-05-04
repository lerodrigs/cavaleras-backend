using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class OrderStatusValidator: AbstractValidator<OrderStatus>
    {
        public OrderStatusValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException("Object Invalid");  });

            RuleFor(x => x.description)
                .NotEmpty().WithMessage("Informe a descrição do status")
                .NotNull().WithMessage("Informe a descrição do status");
        }
    }
}
