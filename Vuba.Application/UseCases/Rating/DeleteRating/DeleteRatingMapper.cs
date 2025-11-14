using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Rating.DeleteRating
{
    public sealed class DeleteRatingMapper : AutoMapper.Profile
    {
        public DeleteRatingMapper()
        {
            CreateMap<DeleteRatingRequest, Domain.Entities.Rating>();
            CreateMap<Domain.Entities.Rating, DeleteRatingResponse>();
        }
    }
}
