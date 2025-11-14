using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Application.UseCases.Genre.GetGenre;

namespace Vuba.Application.UseCases.Movie.UpdateMovie
{
    public sealed record UpdateMovieRequest(int Id, string Title, string Synopsis, DateTime ReleaseYear, string Description, string AgeGroup,
                                            string Director, int Duration, List<GetGenreRequest> Genre, IFormFile? MovieFile, IFormFile? ThumbFile)
                            : IRequest<UpdateMovieResponse>;
}
