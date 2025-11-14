using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Season.UpdateSeason
{
    public sealed class UpdateSeasonHandler : IRequestHandler<UpdateSeasonRequest, UpdateSeasonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeasonRepository _seasonRepository;
        private readonly IMapper _mapper;

        public UpdateSeasonHandler(IUnitOfWork unitOfWork, ISeasonRepository seasonRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _seasonRepository = seasonRepository;
            _mapper = mapper;
        }

        public async Task<UpdateSeasonResponse> Handle(UpdateSeasonRequest request, CancellationToken cancellationToken)
        {
            _mapper.Map<Domain.Entities.Season>(request);

            var season = await _seasonRepository.Get(request.Id, cancellationToken);
            if (season == null) return default;

            season.Name = request.Name;
            season.SerieId = request.SerieId;

            _seasonRepository.Update(season);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<UpdateSeasonResponse>(season);
        }
    }
}
