using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Entities;

namespace Vuba.Domain.Validators
{
    public class SeasonValidator : AbstractValidator<Season>
    {
        public SeasonValidator()
        {
            RuleFor(e => e.Name)
            .Length(5, 50).WithMessage("O nome deve ter entre 5 e 50 caracteres.");

            RuleFor(e => e.SerieId)
            .GreaterThan(0).WithMessage("O ID da serie deve ser maior que zero.");
        }
    }
}
