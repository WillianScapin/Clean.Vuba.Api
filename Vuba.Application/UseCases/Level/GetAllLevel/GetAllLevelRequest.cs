using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Level.GetAllLevel
{
    public sealed record GetAllLevelRequest
                            : IRequest<List<GetAllLevelResponse>>;
}
