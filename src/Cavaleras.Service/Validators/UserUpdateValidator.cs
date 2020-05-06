using Calaveras.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class UserUpdateValidator : AbstractValidator<User>
    {
        public UserUpdateValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentException("Object Invalid"); });

            RuleFor(x => x.Id)
                .NotNull().WithMessage("Informe o id do cliente")
                .NotEmpty().WithMessage("Informe o id do cliente");

            RuleFor(x => x.cpf)
                .NotNull().WithMessage("Informe o cpf do cliente")
                .NotEmpty().WithMessage("Informe o cpf do cliente");

            RuleFor(x => x.name)
                .NotNull().WithMessage("Informe o nome do cliente")
                .NotEmpty().WithMessage("Informe o nome do cliente");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("Informe o email do cliente")
                .NotEmpty().WithMessage("Informe o email do cliente")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(x => x.birthday)
                .NotNull().WithMessage("Informe a data de nascimento do cliente")
                .GreaterThan(DateTime.MinValue).WithMessage("Informe a data de nascimento do cliente");
        }
    }
}
