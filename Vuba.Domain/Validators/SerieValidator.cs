using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Entities;

namespace Vuba.Domain.Validators
{
    public class SerieValidator : AbstractValidator<Serie>
    {
        public SerieValidator()
        {
            // Title: Obrigatório, mínimo de 5 caracteres, máximo de 100 caracteres
            RuleFor(s => s.Title)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .Length(5, 100).WithMessage("O título deve ter entre 5 e 100 caracteres.");

            // ReleaseYear: Opcional, mas se fornecido deve ser no passado ou presente
            RuleFor(s => s.ReleaseYear)
                .LessThanOrEqualTo(DateTime.UtcNow).When(s => s.ReleaseYear.HasValue).WithMessage("O ano de lançamento deve ser no passado ou presente.");

            // Description: Opcional, mas se fornecido deve ter no máximo 1000 caracteres
            RuleFor(s => s.Description)
                .MaximumLength(1000).WithMessage("A descrição deve ter no máximo 1000 caracteres.");

            // AgeGroup: Obrigatório, deve ser um valor entre "G", "PG", "PG-13", "R" ou "NC-17"
            RuleFor(s => s.AgeGroup)
                .NotEmpty().WithMessage("A classificação etária é obrigatória.");

            // Creator: Obrigatório, mínimo de 3 caracteres, máximo de 50 caracteres
            RuleFor(s => s.Creator)
                .NotEmpty().WithMessage("O nome do criador é obrigatório.")
                .Length(3, 50).WithMessage("O nome do criador deve ter entre 3 e 50 caracteres.");

            RuleFor(s => s.LevelId)
                .GreaterThan(0).WithMessage("O id do nível deve ser maior que 0");
        }
    }
}
