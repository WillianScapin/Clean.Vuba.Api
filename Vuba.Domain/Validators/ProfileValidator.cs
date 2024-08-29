using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Entities;

namespace Vuba.Domain.Validators
{
    public class ProfileValidator : AbstractValidator<Profile>
    {
        public ProfileValidator()
        {
            // Name: Obrigatório, mínimo de 3 caracteres, máximo de 50 caracteres
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(3, 50).WithMessage("O nome deve ter entre 3 e 50 caracteres.");

            // ProfileUrl: Deve ser uma URL válida
            RuleFor(p => p.ProfileUrl)
                .NotEmpty().WithMessage("A URL do perfil é obrigatória.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("A URL do perfil deve ser válida.");

            // AccountId: Deve ser um valor positivo
            RuleFor(p => p.AccountId)
                .GreaterThan(0).WithMessage("O ID da conta deve ser maior que zero.");

        }
    }
}
