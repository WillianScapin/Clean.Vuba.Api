using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Profile.CreateProfile
{
    public sealed record CreateProfileRequest(string Name, string ProfileUrl,
                                              int AccountId, bool IsChildProfile, bool IsActive)
                            : IRequest<CreateProfileResponse>;
}
