using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Season.UpdateSeason
{
    public sealed record UpdateSeasonRequest(int Id, int SerieId, string Name)
                            : IRequest<UpdateSeasonResponse>;
}
