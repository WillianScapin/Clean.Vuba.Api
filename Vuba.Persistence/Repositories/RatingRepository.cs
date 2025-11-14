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
    public class RatingRepository : BaseRepository<Rating>, IRatingRepository
    {
        public RatingRepository(AppDbContext context) : base(context) { }
    }
}
