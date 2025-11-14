using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Season.CreateSeason
{
    public sealed record CreateSeasonRequest(string Name, int SerieId)
                            : IRequest<CreateSeasonResponse>;
}
