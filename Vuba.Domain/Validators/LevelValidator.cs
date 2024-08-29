using FluentValidation;
using Vuba.Domain.Entities;

namespace Vuba.Domain.Validators
{
    public class LevelValidator : AbstractValidator<Level>
    {
        public LevelValidator()
        {
            RuleFor(e => e.Name)
            .Length(5, 50).WithMessage("O nome deve ter entre 5 e 50 caracteres.");
        }
    }
}
