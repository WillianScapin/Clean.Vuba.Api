using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Level.GetLevel
{
    public sealed class GetLevelHandler : IRequestHandler<GetLevelRequest, GetLevelResponse>
    {
        private readonly ILevelRepository _levelRepository;
        private readonly IMapper _mapper;

        public GetLevelHandler(ILevelRepository levelRepository, IMapper mapper)
        {
            _levelRepository = levelRepository;
            _mapper = mapper;
        }

        public async Task<GetLevelResponse> Handle(GetLevelRequest request, CancellationToken cancellationToken)
        {
            var level = await _levelRepository.Get(request.Id, cancellationToken);
            return _mapper.Map<GetLevelResponse>(level);
        }
    }
}
