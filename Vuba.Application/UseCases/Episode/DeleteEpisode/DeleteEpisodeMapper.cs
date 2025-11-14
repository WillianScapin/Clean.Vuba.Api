namespace Vuba.Application.UseCases.Episode.DeleteEpisode
{
    public sealed class DeleteEpisodeMapper : AutoMapper.Profile
    {
        public DeleteEpisodeMapper()
        {
            CreateMap<DeleteEpisodeRequest, Domain.Entities.Episode>();
            CreateMap<Domain.Entities.Episode, DeleteEpisodeResponse>();
        }
    }
}
