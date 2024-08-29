using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Profile.GetAllProfile
{
    public sealed class GetAllProfileMapper : AutoMapper.Profile
    {
        public GetAllProfileMapper()
        {
            CreateMap<Domain.Entities.Profile, GetAllProfileResponse>();
        }
    }
}
