using Vuba.Application.UseCases.Genre.CreateGenre;
using Vuba.Application.UseCases.Rating.CreateRating;

namespace Vuba.Application.UseCases.Movie.CreateMovie
{
    public sealed class CreateMovieResponse
    {
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Description { get; set; }
        public string AgeGroup { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public string MovieUrl { get; set; }
        public string ThumbUrl { get; set; }


        public List<CreateGenreResponse> Genre { get; set; }
        public List<CreateRatingResponse> Rating { get; set; }
    }

}
