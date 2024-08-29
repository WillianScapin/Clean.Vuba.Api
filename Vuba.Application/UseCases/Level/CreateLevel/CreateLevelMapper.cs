namespace Vuba.Application.UseCases.Level.CreateLevel
{
    public sealed class CreateLevelMapper : AutoMapper.Profile
    {
        public CreateLevelMapper()
        {
            CreateMap<CreateLevelRequest, Domain.Entities.Level>();
            CreateMap<Domain.Entities.Level, CreateLevelResponse>();
        }
    }
}
