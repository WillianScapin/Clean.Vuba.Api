using Vuba.Domain.Entities;

namespace Vuba.Domain.Interfaces
{
    public interface IMediaRepository : IBaseRepository<Media>
    {
        Media GetMedias(int genreCount, int itensPerGenre);
    }
}
