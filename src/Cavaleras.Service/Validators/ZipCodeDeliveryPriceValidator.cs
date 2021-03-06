﻿using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class ZipCodeDeliveryPriceValidator: AbstractValidator<ZipCodeDeliveryPrice>
    {
        public ZipCodeDeliveryPriceValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException("Object Invalid"); });

            RuleFor(x => x.idzipcodemin)
                .NotNull().WithMessage("Informe o id do CEP mínimo")
                .GreaterThan(0).WithMessage("Informe o Id do CEP mínimo");

            RuleFor(x => x.idzipcodemax)
                .NotNull().WithMessage("Informe o id do CEP máximo")
                .GreaterThan(0).WithMessage("Informe o Id do CEP máximo");

            RuleFor(X => X.price)
                .NotNull().WithMessage("Informe o preço de taxa de entrega da parametrização de CEP")
                .GreaterThan(0).WithMessage("Informe o preço de taxa de entrega da parametrização de CEP");
        }
    }
}
