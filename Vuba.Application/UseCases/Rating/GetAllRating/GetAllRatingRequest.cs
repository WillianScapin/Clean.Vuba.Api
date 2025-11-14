using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Rating.GetAllRating
{
    public sealed record GetAllRatingRequest
                            : IRequest<List<GetAllRatingResponse>>;
}
