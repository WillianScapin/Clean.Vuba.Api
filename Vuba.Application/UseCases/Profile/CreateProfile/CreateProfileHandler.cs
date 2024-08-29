using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Profile.CreateProfile
{
    public sealed class CreateProfileHandler : IRequestHandler<CreateProfileRequest, CreateProfileResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public CreateProfileHandler(IUnitOfWork unitOfWork, IProfileRepository profileRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        public async Task<CreateProfileResponse> Handle(CreateProfileRequest request, CancellationToken cancellationToken)
        {
            var profile = _mapper.Map<Domain.Entities.Profile>(request);

            _profileRepository.Create(profile);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateProfileResponse>(profile);
        }
    }
}
