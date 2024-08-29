using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Rating.CreateRating
{
    public sealed class CreateRatingMapper : AutoMapper.Profile
    {
        public CreateRatingMapper()
        {
            CreateMap<CreateRatingRequest, Domain.Entities.Rating>();
            CreateMap<Domain.Entities.Rating, CreateRatingResponse>();
        }
    }
}
