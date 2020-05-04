using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class ZipCodeValidator: AbstractValidator<ZipCode>
    {
        public ZipCodeValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException("Object Invalid"); }); 

            RuleFor(x => x.description)
                .NotNull().WithMessage("Informe o CEP")
                .NotEmpty().WithMessage("Informe o CEP");
        }
    }
}
