using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class OrderStatusUpdateValidator: AbstractValidator<OrderStatus>
    {
        public OrderStatusUpdateValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException("Object Invalid"); });

            RuleFor(x => x.id)
                .NotNull().WithMessage("Informe o id do status do pedido")
                .NotEmpty().WithMessage("Informe o id do status do pedido")
                .GreaterThan(0).WithMessage("Informe o id do status do pedido");

            RuleFor(x => x.description)
                .NotNull().WithMessage("Informe a descrição do status do pedido")
                .NotEmpty().WithMessage("Informe a descrição do status do pedido");
        }
    }
}
