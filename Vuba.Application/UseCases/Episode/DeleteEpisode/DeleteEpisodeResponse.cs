using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Episode.DeleteEpisode
{
    public sealed class DeleteEpisodeResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EpisodeNumber { get; set; }
        public string Synopsis { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
