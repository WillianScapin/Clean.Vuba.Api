using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Episode.GetEpisode
{
    public sealed record GetEpisodeRequest(int Id)
                                        :IRequest<GetEpisodeResponse>;
}
