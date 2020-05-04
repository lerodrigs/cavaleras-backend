using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class ProductUpdateValidator : AbstractValidator<Product>
    {
        public ProductUpdateValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .NotEmpty()
                .OnAnyFailure(x => { throw new ArgumentException("Object Invalid"); });

            RuleFor(x => x.id)
                .NotNull().WithMessage("Informe o id do produto")
                .NotEmpty().WithMessage("Informe o id do produto");

            RuleFor(x => x.description)
                .NotNull().WithMessage("Informe a descrição do produto")
                .NotEmpty().WithMessage("Informe a descrição do produto");

            RuleFor(x => x.price)
                .NotNull().WithMessage("Informe o preço do produto")
                .NotEmpty().WithMessage("Informe o preço do produto")
                .GreaterThan(0).WithMessage("Informe o preço do produto");
        }
    }
}
