using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Media.GetAllMedia
{
    public sealed record GetMediaRequest(int genreCount, int itensPerGenre)
                         : IRequest<GetMediaResponse>;
}
