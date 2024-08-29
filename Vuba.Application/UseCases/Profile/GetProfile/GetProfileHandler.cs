using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Profile.GetProfile
{
    public sealed class GetProfileHandler : IRequestHandler<GetProfileRequest, GetProfileResponse>
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public GetProfileHandler(IProfileRepository profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        public async Task<GetProfileResponse> Handle(GetProfileRequest request, CancellationToken cancellationToken)
        {
            var profile = await _profileRepository.Get(request.Id, cancellationToken);
            return _mapper.Map<GetProfileResponse>(profile);
        }
    }
}
