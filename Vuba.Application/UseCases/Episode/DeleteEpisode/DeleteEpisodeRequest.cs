using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Episode.DeleteEpisode
{
    public sealed record DeleteEpisodeRequest(int Id)
                                            : IRequest<DeleteEpisodeResponse>;
}
