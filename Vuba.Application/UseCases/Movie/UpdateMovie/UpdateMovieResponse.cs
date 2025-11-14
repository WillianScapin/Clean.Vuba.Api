using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Movie.UpdateMovie
{
    public sealed class UpdateMovieResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Description { get; set; }
        public string AgeGroup { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public string MovieUrl { get; set; }
        public string ThumbUrl { get; set; }
    }
}
