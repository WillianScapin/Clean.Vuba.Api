using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Rating.GetRating
{
    public sealed class GetRatingMapper : AutoMapper.Profile
    {
        public GetRatingMapper()
        {
            CreateMap<GetRatingRequest, Domain.Entities.Rating>();
            CreateMap<Domain.Entities.Rating, GetRatingResponse>();
        }
    }
}
