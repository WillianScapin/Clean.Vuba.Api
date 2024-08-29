using MediatR;
using Microsoft.AspNetCore.Http;
using Vuba.Application.UseCases.Genre.GetGenre;

namespace Vuba.Application.UseCases.Serie.UpdateSerie
{
    public sealed record UpdateSerieRequest(int Id, string Title, DateTime? ReleaseYear, string Description, string AgeGroup, 
                                            string Creator, int? LevelId, List<GetGenreRequest> Genre)
                            : IRequest<UpdateSerieResponse>;
}
