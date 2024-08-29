using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Level.UpdateLevel
{
    public sealed record UpdateLevelRequest(int Id, string Name)
                            : IRequest<UpdateLevelResponse>;
}
