using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Serie.DeleteSerie
{
    public sealed record DeleteSerieRequest(int Id)
                            : IRequest<DeleteSerieResponse>;
}
