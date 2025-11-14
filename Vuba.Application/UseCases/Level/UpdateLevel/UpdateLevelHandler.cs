using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Level.UpdateLevel
{
    public sealed class UpdateLevelHandler : IRequestHandler<UpdateLevelRequest, UpdateLevelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILevelRepository _levelRepository;
        private readonly IMapper _mapper;

        public UpdateLevelHandler(IUnitOfWork unitOfWork, ILevelRepository levelRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _levelRepository = levelRepository;
            _mapper = mapper;
        }

        public async Task<UpdateLevelResponse> Handle(UpdateLevelRequest request, CancellationToken cancellationToken)
        {
            var level = await _levelRepository.Get(request.Id, cancellationToken);
            if (level == null) return default;

            level.Name = request.Name;

            _levelRepository.Update(level);

            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<UpdateLevelResponse>(level);
        }
    }
}
