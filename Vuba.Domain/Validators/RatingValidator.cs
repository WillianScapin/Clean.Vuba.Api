using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Entities;

namespace Vuba.Domain.Validators
{
    public class RatingValidator : AbstractValidator<Rating>
    {
        public RatingValidator()
        {
            RuleFor(r => r.ContentId)
            .GreaterThan(0).WithMessage("O ID do conteúdo deve ser maior que zero.");

            // ContentType: Obrigatório, deve ser 'movie', 'series' ou 'episode'
            RuleFor(r => r.ContentType)
                .NotEmpty().WithMessage("O tipo de conteúdo é obrigatório.")
                .Must(contentType => new[] { "movie", "series", "episode" }.Contains(contentType))
                .WithMessage("O tipo de conteúdo deve ser 'movie', 'series' ou 'episode'.");

            // UserId: Deve ser um valor positivo
            RuleFor(r => r.UserId)
                .GreaterThan(0).WithMessage("O ID do usuário deve ser maior que zero.");

            // Score: Deve ser um valor entre 1 e 10
            RuleFor(r => r.Score)
                .InclusiveBetween(1, 10).WithMessage("A pontuação deve estar entre 1 e 10.");

            // Timestamp: Deve ser uma data no passado ou presente
            RuleFor(r => r.Timestamp)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("O timestamp deve ser no passado ou presente.");

        }
    }
}
