using Vuba.Domain.Entities;

namespace Vuba.Domain.Interfaces
{
    public interface IProfileRepository : IBaseRepository<Domain.Entities.Profile>
    {
        public void Create(Profile profile);
    }
}
