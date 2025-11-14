using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Rating.GetRating
{
    public sealed record GetRatingRequest(int Id)
                            : IRequest<GetRatingResponse>;
}
