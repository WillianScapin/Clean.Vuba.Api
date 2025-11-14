using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Application.UseCases.Movie.GetAllMovie;
using Vuba.Application.UseCases.Serie.GetAllSerie;

namespace Vuba.Application.UseCases.Media.GetAllMedia
{
    public sealed class GetMediaResponse
    {
        public List<GetAllMovieResponse> MovieList { get; set; }
        public List<GetAllSerieResponse> SerieList { get; set; }
    }
}
