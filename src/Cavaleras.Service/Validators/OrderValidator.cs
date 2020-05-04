using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class OrderValidator: AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException("Object invalid."); });

            RuleFor(x => x.idclient)
                .NotNull().WithMessage("Informe o id do cliente")
                .NotEmpty().WithMessage("Informe o id do cliente");

            RuleFor(x => x.iddeliveryman)
                .NotNull().WithMessage("Informe o id do entregador")
                .NotEmpty().WithMessage("Informe o id do entregador")
                .GreaterThan(0).WithMessage("Informe o id do entregador");

            RuleFor(x => x.idstore)
                .NotNull().WithMessage("Informe o id da loja")
                .NotEmpty().WithMessage("Informe o id da loja")
                .GreaterThan(0).WithMessage("Informe o id da loja");

            RuleFor(x => x.idzipcodeliveryprice)
                .NotNull().WithMessage("Informe o id da taxa de entrega")
                .NotEmpty().WithMessage("Informe o id da taxa de entrega")
                .GreaterThan(0).WithMessage("Informe o id da taxa de entrega");

            RuleFor(x => x.total_price)
                .NotNull().WithMessage("Informe o preço total do pedido") 
                .NotEmpty().WithMessage("Informe o preço total do pedido")
                .GreaterThan(0).WithMessage("Informe o preço total do pedido");

            RuleFor(x => x.signature)
                .NotNull().WithMessage("Informe a assinatura do cliente")
                .NotEmpty().WithMessage("Informe a assinatura do cliente");

            RuleFor(X => X.date_order)
                .NotNull().WithMessage("Informe a data do pedido")
                .NotEmpty().WithMessage("Informe a data do pedido")
                .GreaterThan(DateTime.MinValue);

            RuleFor(x => x.descritption)
                .NotNull().WithMessage("Informe a descrição/observação do produto.")
                .NotEmpty().WithMessage("Informe a descrição/observação do produto.");

        }
    }
}
