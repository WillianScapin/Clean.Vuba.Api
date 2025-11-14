using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Application.UseCases.Genre.GetGenre;
using Vuba.Application.UseCases.Rating.GetRating;

namespace Vuba.Application.UseCases.Movie.GetMovie
{
    public sealed class GetMovieResponse
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


        public ICollection<GetGenreResponse> Genre { get; set; }
        public ICollection<GetRatingResponse> Ratings { get; set; }
    }
}
