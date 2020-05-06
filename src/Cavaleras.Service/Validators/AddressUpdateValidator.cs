using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class AddressUpdateValidator: AbstractValidator<Address>
    {
        public AddressUpdateValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException("Object Invalid"); });

            RuleFor(x => x.id)
                .NotNull().WithMessage("Informe o id do endereço")
                .NotEmpty().WithMessage("Informe o id do endereço")
                .GreaterThan(0).WithMessage("informe o id do endereço");

            RuleFor(x => x.idclient)
                .NotNull().WithMessage("Informe o id do cliente")
                .NotEmpty().WithMessage("Informe o id do cliente");

            RuleFor(x => x.street)
                .NotNull().WithMessage("Informe a rua/avenida do endereço")
                .NotEmpty().WithMessage("Informe a rua/avenida do endereço");

            RuleFor(x => x.number)
                .NotNull().WithMessage("Informe o número do endereço")
                .NotEmpty().WithMessage("Informe o número do endereço");

            RuleFor(x => x.neighborhood)
                .NotNull().WithMessage("Informe o bairro do endereço")
                .NotEmpty().WithMessage("Informe o bairro do endereço");

            RuleFor(x => x.city)
                .NotNull().WithMessage("Informe a cidade do endereço")
                .NotEmpty().WithMessage("Informe a cidade do endereço");

            RuleFor(x => x.state)
                .NotNull().WithMessage("Informe o estado do endereço")
                .NotEmpty().WithMessage("Informe o estado do endereço");

            RuleFor(x => x.zipcode)
                .NotEmpty().WithMessage("Informe o CEP do endereço")
                .NotNull().WithMessage("Informe o CEP do endereço");
        }
    }
}
