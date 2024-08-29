using MediatR;
using Microsoft.AspNetCore.Http;
using Vuba.Application.UseCases.Genre.GetGenre;

namespace Vuba.Application.UseCases.Movie.CreateMovie
{
    //public sealed record CreateMovieRequest(string Title, string Synopsis, DateTime ReleaseYear, string Description, string AgeGroup,
    //                                        string Director, int Duration, List<GetGenreRequest> Genre, IFormFile? MovieFile, IFormFile? ThumbFile)
    //                        : IRequest<CreateMovieResponse>;

    public sealed class CreateMovieRequest : IRequest<CreateMovieResponse>
    { 
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Description { get; set; }
        public string AgeGroup { get; set; }
        public string Director { get; set; }
        public string Duration { get; set; }


        public List<GetGenreRequest> Genre { get; set; }
        public IFormFile? MovieFile { get; set; }
        public IFormFile? ThumbFile { get; set; }
    }

}
