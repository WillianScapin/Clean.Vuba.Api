using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Entities;

namespace Vuba.Domain.Validators
{
    public class LoginValidator : AbstractValidator<Login>
    {
        public LoginValidator()
        {
            //Email
            RuleFor(custommer => custommer.Email)
            .NotNull().WithMessage("O e-mail não pode ser nulo")
            .NotEmpty().WithMessage("O e-mail não pode ser vazio")
            .EmailAddress().WithMessage("O e-mail deve ser um e-mail válido");

            //Password
            RuleFor(user => user.Password)
            .NotEmpty().WithMessage("A senha é obrigatória.")
            .MinimumLength(8).WithMessage("A senha deve ter pelo menos 8 caracteres.")
            .Matches(@"[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
            .Matches(@"\d").WithMessage("A senha deve conter pelo menos um número.")
            .Matches("[!@#$%^&*(),.?\":{ }|<>]").WithMessage("A senha deve conter pelo menos três caracteres especiais.");
        }
    }
}
