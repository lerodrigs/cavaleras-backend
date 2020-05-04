using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class ZipCodeUpdateValidator: AbstractValidator<ZipCode>
    {
        public ZipCodeUpdateValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException("Object Invalid"); });

            RuleFor(x => x.id)
                .NotNull().WithMessage("Informe o id do cep")
                .NotEmpty().WithMessage("Informe o id do cep")
                .GreaterThan(0).WithMessage("Informe o id do cep");

            RuleFor(x => x.description)
                .NotNull().WithMessage("Informe o CEP")
                .NotEmpty().WithMessage("Informe o CEP");
        }
    }
}
