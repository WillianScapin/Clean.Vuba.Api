using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Profile.GetProfile
{
    public sealed class GetProfileMapper : AutoMapper.Profile
    {
        public GetProfileMapper()
        {
            CreateMap<GetProfileRequest, Domain.Entities.Profile>();
            CreateMap<Domain.Entities.Profile, GetProfileResponse>();
        }
    }
}
