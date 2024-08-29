using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Profile.DeleteProfile
{
    public sealed class DeleteProfileMapper : AutoMapper.Profile
    {
        public DeleteProfileMapper()
        {
            CreateMap<DeleteProfileRequest, Domain.Entities.Profile>();
            CreateMap<Domain.Entities.Profile, DeleteProfileResponse>();
        }
    }
}
