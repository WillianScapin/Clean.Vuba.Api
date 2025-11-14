namespace Vuba.Application.UseCases.Movie.GetMovie
{
    public sealed class GetMovieMapper : AutoMapper.Profile
    {
        public GetMovieMapper() 
        {
            CreateMap<GetMovieRequest, Domain.Entities.Movie>();
            CreateMap<Domain.Entities.Movie, GetMovieResponse>();
        }
    }
}
