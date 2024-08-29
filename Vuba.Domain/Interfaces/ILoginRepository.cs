using Vuba.Domain.Entities;

namespace Vuba.Domain.Interfaces
{
    public interface ILoginRepository : IBaseRepository<Login>
    {
        Task<Account> Get(string Email, string Password, CancellationToken cancellationToken);
    }
}
