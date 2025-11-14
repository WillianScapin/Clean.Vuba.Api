using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Level.GetLevel
{
    public sealed record GetLevelRequest(int Id)
                            : IRequest<GetLevelResponse>;
}
