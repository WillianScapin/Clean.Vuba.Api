using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Episode.GetAllEpisode
{
    public sealed record GetAllEpisodeRequest
                        : IRequest<List<GetAllEpisodeResponse>>
    {
    }
}
