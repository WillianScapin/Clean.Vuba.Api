using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Movie.GetMovie
{
    public sealed record GetMovieRequest(int Id)
                            : IRequest<GetMovieResponse>;
}
