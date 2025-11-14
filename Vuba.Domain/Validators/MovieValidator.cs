using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Entities;

namespace Vuba.Domain.Validators
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            // Title: Obrigatório, mínimo de 5 caracteres, máximo de 100 caracteres
            RuleFor(m => m.Title)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .Length(5, 100).WithMessage("O título deve ter entre 5 e 100 caracteres.");

            // Synopsis: Opcional, mas se fornecido deve ter no máximo 500 caracteres
            RuleFor(m => m.Synopsis)
                .MaximumLength(500).WithMessage("A sinopse deve ter no máximo 500 caracteres.");

            // ReleaseYear: Deve ser uma data no passado ou presente
            RuleFor(m => m.ReleaseYear)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("O ano de lançamento deve ser no passado ou presente.");

            // AgeGroup: Obrigatório, deve ser um valor entre "G", "PG", "PG-13", "R" ou "NC-17"
            RuleFor(m => m.AgeGroup)
                .NotEmpty().WithMessage("A classificação etária é obrigatória.");

            // Director: Obrigatório, mínimo de 3 caracteres, máximo de 50 caracteres
            RuleFor(m => m.Director)
                .NotEmpty().WithMessage("O nome do diretor é obrigatório.")
                .Length(3, 50).WithMessage("O nome do diretor deve ter entre 3 e 50 caracteres.");

            // MovieUrl: Deve ser uma URL válida
            RuleFor(m => m.MovieUrl)
                .NotEmpty().WithMessage("A URL do filme é obrigatória.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("A URL do filme deve ser válida.");

            // FileKey: Obrigatório
            RuleFor(m => m.FileKey)
                .NotEmpty().WithMessage("A chave do arquivo é obrigatória.");

            // Duration: Deve ser um valor positivo
            RuleFor(m => m.Duration)
                .GreaterThan(0).WithMessage("A duração deve ser maior que zero.");

            // ThumbUrl: Deve ser uma URL válida
            RuleFor(m => m.ThumbUrl)
                .NotEmpty().WithMessage("A URL da miniatura é obrigatória.")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).WithMessage("A URL da miniatura deve ser válida.");

        }
    }
}
