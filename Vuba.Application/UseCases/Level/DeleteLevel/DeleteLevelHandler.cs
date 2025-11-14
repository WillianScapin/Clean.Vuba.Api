using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Level.DeleteLevel
{
    public sealed class DeleteLevelHandler : IRequestHandler<DeleteLevelRequest, DeleteLevelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILevelRepository _levelRepository;
        private readonly IMapper _mapper;

        public async Task<DeleteLevelResponse> Handle(DeleteLevelRequest request, CancellationToken cancellationToken)
        {
            var level = await _levelRepository.Get(request.Id, cancellationToken);
            if (level == null) return default;

            _levelRepository.Delete(level);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteLevelResponse>(level);
        }
    }
}
