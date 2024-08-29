using Vuba.Application.UseCases.Genre.GetAllGenre;
using Vuba.Application.UseCases.Rating.GetAllRating;

namespace Vuba.Application.UseCases.Movie.GetAllMovie
{
    public sealed class GetAllMovieResponse
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


        public List<GetAllGenreResponse> Genre { get; set; }
        public List<GetAllRatingResponse> Ratings { get; set; }
    }
}
