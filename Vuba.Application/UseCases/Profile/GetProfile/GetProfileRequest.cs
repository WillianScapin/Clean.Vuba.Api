using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Profile.GetProfile
{
    public sealed record GetProfileRequest(int Id)
                            : IRequest<GetProfileResponse>;
}
