using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Rating.UpdateRating
{
    public sealed class UpdateRatingMapper : AutoMapper.Profile
    {
        public UpdateRatingMapper() 
        {
            CreateMap<UpdateRatingRequest, Domain.Entities.Rating>();
            CreateMap<Domain.Entities.Rating, UpdateRatingResponse>();
        }
    }
}
