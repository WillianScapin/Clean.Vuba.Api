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
    public class EpisodeRepository : BaseRepository<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(AppDbContext context) : base(context) { }

        public void Create(Episode episode)
        {
            episode.ReleaseDate = DateTime.SpecifyKind(episode.ReleaseDate, DateTimeKind.Utc);
        }

    }
}
