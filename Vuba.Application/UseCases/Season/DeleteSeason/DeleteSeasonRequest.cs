using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Season.DeleteSeason
{
    public sealed record DeleteSeasonRequest(int Id)
                            : IRequest<DeleteSeasonResponse>;
}
