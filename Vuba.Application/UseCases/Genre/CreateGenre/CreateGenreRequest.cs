using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Genre.CreateGenre
{
    public sealed record CreateGenreRequest(string Name)
                            : IRequest<CreateGenreResponse>;
}
