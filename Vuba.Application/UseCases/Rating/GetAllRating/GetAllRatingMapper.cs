using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Rating.GetAllRating
{
    public sealed class GetAllRatingMapper : AutoMapper.Profile
    {
        public GetAllRatingMapper() 
        {
            CreateMap<Domain.Entities.Rating, GetAllRatingResponse>();
        }
    }
}
