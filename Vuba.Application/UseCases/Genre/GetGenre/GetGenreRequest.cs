using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Genre.GetGenre
{
    public sealed record GetGenreRequest(int Id)
                            : IRequest<GetGenreResponse>;
}
