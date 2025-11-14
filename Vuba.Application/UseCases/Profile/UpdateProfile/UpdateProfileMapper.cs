using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Profile.UpdateProfile
{
    public sealed class UpdateProfileMapper : AutoMapper.Profile
    {
        public UpdateProfileMapper()
        {
            CreateMap<UpdateProfileRequest, Domain.Entities.Profile>();
            CreateMap<Domain.Entities.Profile, UpdateProfileResponse>();
        }
    }
}
