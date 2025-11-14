using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Rating.DeleteRating
{
    public sealed record DeleteRatingRequest(int Id)
                            : IRequest<DeleteRatingResponse>;
}
