using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Rating.CreateRating
{
    public sealed record CreateRatingRequest(int ContentId, string ContentType,
                                             int UserId, int Score, DateTime Timestamp)
                            : IRequest<CreateRatingResponse>;
}
