using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Profile.UpdateProfile
{
    public sealed class UpdateProfileHandler : IRequestHandler<UpdateProfileRequest, UpdateProfileResponse>
    {
        private readonly IUnitOfWork _unityOfWork;
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public UpdateProfileHandler(IUnitOfWork unityOfWork, IProfileRepository profileRepository, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        public async Task<UpdateProfileResponse> Handle(UpdateProfileRequest request, CancellationToken cancellationToken)
        {
            var profile = await _profileRepository.Get(request.Id, cancellationToken);
            if (profile == null) return default;

            profile.Name = request.Name;
            profile.ProfileUrl = request.ProfileUrl;
            profile.AccountId = request.AccountId;
            profile.IsChildProfile = request.IsChildProfile;
            profile.IsActive = request.IsActive;

            _profileRepository.Update(profile);
            await _unityOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateProfileResponse>(profile);
        }
    }
}
