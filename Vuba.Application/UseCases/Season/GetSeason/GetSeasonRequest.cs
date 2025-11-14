using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Season.GetSeason
{
    public sealed record GetSeasonRequest(int Id)
                            : IRequest<GetSeasonResponse>;
}
