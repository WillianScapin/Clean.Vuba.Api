using Vuba.Domain.Entities;
using Vuba.Domain.Interfaces;
using Vuba.Persistence.Context;

namespace Vuba.Persistence.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(AppDbContext context) : base(context) { }

        public void Create(Movie movie)
        {
            movie.ReleaseYear = DateTime.SpecifyKind(movie.ReleaseYear, DateTimeKind.Utc);

            List<Genre> genreList = new();
            foreach (var item in movie.Genre)
            {
                var genre = _context.Genre.Find(item.Id);
                genreList.Add(genre);
            }

            if (genreList.FirstOrDefault() == null)
                movie.Genre = null;
            else
                movie.Genre = genreList;

            movie.Rating = null;

            _context.Movie.Add(movie);
        }
    }
}
