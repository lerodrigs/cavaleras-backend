using Calaveras.Domain.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cavaleras.Service.Validators
{
    public class AuthenticateDtoValidator: AbstractValidator<AuthenticateDto>
    {
        public AuthenticateDtoValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentNullException("Object is null."); });

            RuleFor(x => x.email)
                .NotNull()
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email inválido.");

            RuleFor(x => x.password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Senha inválida.");
        }
    }
}
