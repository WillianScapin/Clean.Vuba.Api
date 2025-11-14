using AutoMapper;
using MediatR;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Level.GetAllLevel
{
    public sealed class GetAllLevelHandler : IRequestHandler<GetAllLevelRequest, List<GetAllLevelResponse>>
    {
        private readonly ILevelRepository _levelRepository;
        private readonly IMapper _mapper;

        public GetAllLevelHandler(ILevelRepository levelRepository, IMapper mapper)
        {
            _levelRepository = levelRepository;
            _mapper = mapper;
        }

        async Task<List<GetAllLevelResponse>> IRequestHandler<GetAllLevelRequest, List<GetAllLevelResponse>>.Handle(GetAllLevelRequest request, CancellationToken cancellationToken)
        {
            var levels = await _levelRepository.GetAll(cancellationToken);
            return _mapper.Map<List<GetAllLevelResponse>>(levels);
        }
    }
}
