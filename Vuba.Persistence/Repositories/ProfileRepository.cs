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
    public class ProfileRepository : BaseRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(AppDbContext context) : base(context) { }


        public void Create(Profile profile)
        {
            var account = _context.Account.Find(profile.AccountId);
            profile.Account = account;

            _context.Profile.Add(profile);
        }
    }
}
