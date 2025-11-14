using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Level.DeleteLevel
{
    public sealed record DeleteLevelRequest(int Id)
                            : IRequest<DeleteLevelResponse>;
}
