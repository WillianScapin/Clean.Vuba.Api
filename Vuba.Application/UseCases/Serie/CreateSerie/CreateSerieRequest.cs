using MediatR;
using Microsoft.AspNetCore.Http;
using Vuba.Application.UseCases.Genre.GetGenre;

namespace Vuba.Application.UseCases.Serie.CreateSerie
{
    public sealed record CreateSerieRequest(string Title, DateTime? ReleaseYear, string Description, string AgeGroup,
                                            string Creator, int? LevelId, List<GetGenreRequest> Genre)
                            : IRequest<CreateSerieResponse>;
}
