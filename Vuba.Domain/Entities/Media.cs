using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Domain.Entities
{
    public sealed class Media : BaseEntity
    {
        public List<Movie> movieList { get; set; }
        public List<Serie> serieList { get; set; }
    }
}
