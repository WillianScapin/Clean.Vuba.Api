using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Episode.CreateEpisode
{
    public sealed record CreateEpisodeResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EpisodeNumber { get; set; }
        public string Synopsis { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string SerieUrl { get; set; }
        public string FileKey { get; set; }
        public int Duration { get; set; }
        public string ThumbUrl { get; set; }
    }
}
