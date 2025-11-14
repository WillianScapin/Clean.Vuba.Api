using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Profile.UpdateProfile
{
    public sealed record UpdateProfileRequest(int Id, string Name, string ProfileUrl,
                                              int AccountId, bool IsChildProfile, bool IsActive)
                            : IRequest<UpdateProfileResponse>;
}
