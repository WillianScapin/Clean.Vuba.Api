using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Serie.GetSerie
{
    public sealed record GetSerieRequest(int Id)
                            : IRequest<GetSerieResponse>;
}
