using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Movie.GetAllMovie
{
    public sealed record GetAllMovieRequest
                            : IRequest<List<GetAllMovieResponse>>;
}
