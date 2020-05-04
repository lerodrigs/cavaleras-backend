using Calaveras.Domain.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class RegisterDtoValidator: AbstractValidator<RegisterUserDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .NotEmpty()
                .OnAnyFailure(erro => { throw new ArgumentException("Object invalid"); });

            RuleFor(x => x.address)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe o endereço");

            RuleFor(x => x.number)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe seu numero");

            RuleFor(x => x.cellphone)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe seu celular");

            RuleFor(x => x.cpf)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe seu CPF");

            RuleFor(x => x.email)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe seu email");

            RuleFor(x => x.password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Informe sua senha");

            RuleFor(x => x.zipcode)
                .NotEmpty()
                .NotEmpty()
                .WithMessage("Informe seu CEP");

            RuleFor(x => x.name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Informe seu nome");
        }
    }
}
