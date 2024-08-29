using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Profile.DeleteProfile
{
    public sealed class DeleteProfileHandler : IRequestHandler<DeleteProfileRequest, DeleteProfileResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public DeleteProfileHandler(IUnitOfWork unitOfWork, IProfileRepository profileRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        public async Task<DeleteProfileResponse> Handle(DeleteProfileRequest request, CancellationToken cancellationToken)
        {
            var profile = await _profileRepository.Get(request.Id, cancellationToken);
            if (profile == null) return default;

            _profileRepository.Delete(profile);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteProfileResponse>(profile);
        }
    }
}
