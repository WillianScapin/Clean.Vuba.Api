using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Level.CreateLevel
{
    public sealed class CreateLevelHandler : IRequestHandler<CreateLevelRequest, CreateLevelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILevelRepository _levelRepository;
        private readonly IMapper _mapper;

        public CreateLevelHandler(IUnitOfWork unitOfWork, ILevelRepository levelRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _levelRepository = levelRepository;
            _mapper = mapper;
        }

        public async Task<CreateLevelResponse> Handle(CreateLevelRequest request, CancellationToken cancellationToken)
        {
            var level = _mapper.Map<Domain.Entities.Level>(request);

            _levelRepository.Create(level);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateLevelResponse>(level);
        }
    }
}
