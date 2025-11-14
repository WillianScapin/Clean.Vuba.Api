using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Season.DeleteSeason
{
    public sealed class DeleteSeasonHandler : IRequestHandler<DeleteSeasonRequest, DeleteSeasonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeasonRepository _seasonRepository;
        private readonly IMapper _mapper;

        public DeleteSeasonHandler(IUnitOfWork unitOfWork, ISeasonRepository seasonRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _seasonRepository = seasonRepository;
            _mapper = mapper;
        }

        public async Task<DeleteSeasonResponse> Handle(DeleteSeasonRequest request, CancellationToken cancellationToken)
        {
            var season = await _seasonRepository.Get(request.Id, cancellationToken);
            if (season == null) return default;

            _seasonRepository.Delete(season);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteSeasonResponse>(season);
        }
    }
}
