using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Episode.CreateEpisode
{
    public sealed record CreateEpisodeRequest(string Title, int EpisodeNumber, string Synopsis, DateTime ReleaseDate,
                                              int Duration, int SeasonId, IFormFile? EpisodeFile, IFormFile? ThumbFile)
                                            : IRequest<CreateEpisodeResponse>;
}
