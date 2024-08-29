using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Genre.UpdateGenre
{
    public sealed record UpdateGenreRequest(int Id, string Name)
                            : IRequest<UpdateGenreResponse>;
}
