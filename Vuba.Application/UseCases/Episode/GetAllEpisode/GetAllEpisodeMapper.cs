namespace Vuba.Application.UseCases.Episode.GetAllEpisode
{
    public sealed class GetAllEpisodeMapper : AutoMapper.Profile
    {
        public GetAllEpisodeMapper()
        {
            CreateMap<Domain.Entities.Episode, GetAllEpisodeResponse>();
        }
    }
}
