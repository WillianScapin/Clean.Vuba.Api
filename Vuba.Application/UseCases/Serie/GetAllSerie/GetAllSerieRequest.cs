using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Serie.GetAllSerie
{
    public sealed record GetAllSerieRequest
                            : IRequest<List<GetAllSerieResponse>>;
}
