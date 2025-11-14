using Microsoft.EntityFrameworkCore;
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
    public sealed class MediaRepository : BaseRepository<Media>, IMediaRepository
    {
        public MediaRepository(AppDbContext context) : base(context) { }

        public Media GetMedias(int genreCount, int itensPerGenre)
        {
            //var genreList = _context.Genre.Take(genreCount).ToList();
            //var movieList = _context.Movie.Include(s => s.Genre).Include(s => s.Rating).ToList().Take(itensPerGenre / 2).ToList();
            //var serieList = _context.Serie.Include(s => s.Genre).Include(s => s.Rating).Include(s => s.Seasons).ToList().Take(itensPerGenre / 2).ToList();


            string urlFalsa = "https://www.rotoscopers.com/wp-content/uploads/2015/09/tumblr_nvhc0dbMgF1s68u0xo1_1280.jpg";

            var movieList = new List<Movie>()
            {
                new Movie("Teste", "Teste de synopsis", DateTime.UtcNow, "18", "Willian", urlFalsa, "filekey", 1, urlFalsa),
                new Movie("Teste", "Teste de synopsis", DateTime.UtcNow, "18", "Willian", urlFalsa, "filekey", 1, urlFalsa)
            };
            var serieList = new List<Serie>() 
            {
                new Serie("Teste", DateTime.UtcNow, "Teste de série", "18", "Willian",  1),
                new Serie("Teste", DateTime.UtcNow, "Teste de série", "18", "Willian", 1)
            };

            return new Media
            {
                movieList = movieList,
                serieList = serieList
            };

        }
    }
}
