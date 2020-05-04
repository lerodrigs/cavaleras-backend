using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .NotEmpty()
                .OnAnyFailure(x => { throw new ArgumentException("Object is invalid."); });

            RuleFor(x => x.address)
                .NotNull().WithMessage("Informe o endereço do cliente")
                .NotEmpty().WithMessage("Informe o endereço do cliente");

            RuleFor(x => x.number)
                .NotNull().WithMessage("Informe o número do endereço do cliente")
                .NotEmpty().WithMessage("Informe o número do endereço do cliente");

            RuleFor(x => x.zipcode)
                .NotNull().WithMessage("Informe o CEP do cliente")
                .NotEmpty().WithMessage("informe o CEP do cliente");

            RuleFor(x => x.name)
                .NotNull().WithMessage("Informe o nome do cliente")
                .NotEmpty().WithMessage("Informe o nome do cliente");

            RuleFor(x => x.PhoneNumber)
                .NotNull().WithMessage("Informe o celular do cliente")
                .NotEmpty().WithMessage("Informe o celular do cliente")
                .MaximumLength(18).WithMessage("Número do celular incorreto");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Informe o email do cliente")
                .NotNull().WithMessage("Informe o email do cliente")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(x => x.cpf)
                .NotEmpty().WithMessage("Informe o CPF do cliente")
                .NotNull().WithMessage("Informe o CPF do cliente");
        }
    }
}
