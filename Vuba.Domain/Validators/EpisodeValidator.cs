using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Entities;

namespace Vuba.Domain.Validators
{
    public class EpisodeValidator : AbstractValidator<Episode>
    {
        public EpisodeValidator()
        {
            RuleFor(e => e.Title)
            .NotEmpty().WithMessage("O título é obrigatório.")
            .Length(5, 100).WithMessage("O título deve ter entre 5 e 100 caracteres.");

            // EpisodeNumber: Deve ser um valor positivo
            RuleFor(e => e.EpisodeNumber)
                .GreaterThan(0).WithMessage("O número do episódio deve ser maior que zero.");

            // Synopsis: Opcional, mas se fornecido deve ter no máximo 500 caracteres
            RuleFor(e => e.Synopsis)
                .MaximumLength(500).WithMessage("A sinopse deve ter no máximo 500 caracteres.");

            // ReleaseDate: Deve ser uma data no passado ou presente
            RuleFor(e => e.ReleaseDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data de lançamento deve ser no passado ou presente.");

            // SerieUrl: Deve ser uma URL válida
            RuleFor(e => e.SerieUrl)
                .NotEmpty().WithMessage("A URL da série é obrigatória.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("A URL da série deve ser válida.");

            // FileKey: Obrigatório
            RuleFor(e => e.FileKey)
                .NotEmpty().WithMessage("A chave do arquivo é obrigatória.");

            // Duration: Deve ser um valor positivo
            RuleFor(e => e.Duration)
                .GreaterThan(0).WithMessage("A duração deve ser maior que zero.");

            // ThumbUrl: Deve ser uma URL válida
            RuleFor(e => e.ThumbUrl)
                .NotEmpty().WithMessage("A URL da miniatura é obrigatória.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("A URL da miniatura deve ser válida.");


            RuleFor(e => e.SeasonId)
                .GreaterThan(0).WithMessage("O id da série deve ser maior que zero.");


        }
    }
}
