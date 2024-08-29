using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Season.CreateSeason
{
    public sealed class CreateSeasonHandler : IRequestHandler<CreateSeasonRequest, CreateSeasonResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISeasonRepository _seasonRepository;
        private readonly IMapper _mapper;

        public CreateSeasonHandler(IUnitOfWork unitOfWork, ISeasonRepository seasonRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _seasonRepository = seasonRepository;
            _mapper = mapper;
        }

        public async Task<CreateSeasonResponse> Handle(CreateSeasonRequest request, CancellationToken cancellationToken)
        {
            var season = _mapper.Map<Domain.Entities.Season>(request);

            _seasonRepository.Create(season);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateSeasonResponse>(season);
        }
    }
}
