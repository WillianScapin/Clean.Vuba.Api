using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Interfaces;

namespace Vuba.Application.UseCases.Genre.UpdateGenre
{
    public sealed class UpdateGenreHandler : IRequestHandler<UpdateGenreRequest, UpdateGenreResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public UpdateGenreHandler(IUnitOfWork unitOfWork, IGenreRepository genreRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task<UpdateGenreResponse> Handle(UpdateGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.Get(request.Id, cancellationToken);
            if (genre == null) return default;

            genre.Name = request.Name;

            _genreRepository.Update(genre);

            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<UpdateGenreResponse>(genre);
        }
    }
}
