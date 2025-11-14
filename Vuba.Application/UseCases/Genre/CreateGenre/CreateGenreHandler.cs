using AutoMapper;
using MediatR;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Genre.CreateGenre
{
    public sealed class CreateGenreHandler : IRequestHandler<CreateGenreRequest, CreateGenreResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public CreateGenreHandler(IUnitOfWork unitOfWork, IGenreRepository genreRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<CreateGenreResponse> Handle(CreateGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = _mapper.Map<Domain.Entities.Genre>(request);

            _genreRepository.Create(genre);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateGenreResponse>(genre);
        }
    }
}
