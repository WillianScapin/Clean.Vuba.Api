using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Movie.DeleteMovie
{
    public sealed record DeleteMovieRequest(int Id)
                            : IRequest<DeleteMovieResponse>;
}
