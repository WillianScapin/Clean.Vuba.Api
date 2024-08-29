using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Season.GetAllSeason
{
    public sealed class GetAllSeasonRequest
                            : IRequest<List<GetAllSeasonResponse>>;
}
