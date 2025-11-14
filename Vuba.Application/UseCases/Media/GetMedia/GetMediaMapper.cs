namespace Vuba.Application.UseCases.Media.GetAllMedia
{
    public sealed class GetMediaMapper : AutoMapper.Profile
    {
        public GetMediaMapper() 
        {
            CreateMap<GetMediaRequest, Domain.Entities.Media>();
            CreateMap<Domain.Entities.Media, GetMediaResponse>();
        }
    }
}
