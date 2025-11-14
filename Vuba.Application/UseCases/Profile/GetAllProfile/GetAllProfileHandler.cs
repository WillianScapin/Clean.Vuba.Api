using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Profile.GetAllProfile
{
    public sealed class GetAllProfileHandler : IRequestHandler<GetAllProfileRequest, List<GetAllProfileResponse>>
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public GetAllProfileHandler(IUnitOfWork unitOfWork, IProfileRepository profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllProfileResponse>> Handle(GetAllProfileRequest request, CancellationToken cancellationToken)
        {
            var profiles = await _profileRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllProfileResponse>>(profiles);
        }
    }
}
