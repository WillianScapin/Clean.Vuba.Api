using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Entities;
using Vuba.Domain.Interfaces;
using Vuba.Persistence.Context;

namespace Vuba.Persistence.Repositories
{
    public class LoginRepository : BaseRepository<Login>, ILoginRepository
    {
        public LoginRepository(AppDbContext context) : base(context) { }

        public async Task<Account> Get(string Email, string Password, CancellationToken cancellationToken)
        {
            return await _context.Account.Where(acc => acc.Email == Email && acc.Password == Password).FirstOrDefaultAsync();
        }
    }
}
