using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Genre.DeleteGenre
{
    public sealed class DeleteGenreHandler : IRequestHandler<DeleteGenreRequest, DeleteGenreResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public DeleteGenreHandler(IUnitOfWork unitOfWork, IGenreRepository genreRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<DeleteGenreResponse> Handle(DeleteGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.Get(request.Id, cancellationToken);

            if (genre == null) return default;

            _genreRepository.Delete(genre);
            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<DeleteGenreResponse>(genre);
        }
    }
}
