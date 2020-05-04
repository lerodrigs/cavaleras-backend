﻿using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class StoreUpdateValidator: AbstractValidator<Store>
    {
        public StoreUpdateValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException("Object Invalid"); });

            RuleFor(x => x.id)
                .NotNull().WithMessage("Informe o id da loja")
                .NotEmpty().WithMessage("Informe o id da loja")
                .GreaterThan(0).WithMessage("Informe o id da loja");

            RuleFor(x => x.address)
                .NotNull().WithMessage("informe o endereço da loja")
                .NotEmpty().WithMessage("informe o endereço da loja");

            RuleFor(x => x.description)
                .NotEmpty().WithMessage("Informe a descrição da loja")
                .NotNull().WithMessage("Informe a descrição da loja");

            RuleFor(x => x.number)
                .NotNull().WithMessage("Informe o número do endereço da loja")
                .NotEmpty().WithMessage("Informe o número do endereço da loja");

            RuleFor(x => x.time_delivery)
                .NotNull().WithMessage("Informe o tempo de espera")
                .NotEmpty().WithMessage("Informe o tempo de espera");
        }
    }
}
