using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Genre.DeleteGenre
{
    public sealed record DeleteGenreRequest(int Id)
                            : IRequest<DeleteGenreResponse>;
}
