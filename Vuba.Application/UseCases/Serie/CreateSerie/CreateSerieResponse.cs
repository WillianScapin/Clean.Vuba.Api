using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Serie.CreateSerie
{
    public sealed class CreateSerieResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseYear { get; set; }
        public string Description { get; set; }
        public string AgeGroup { get; set; }
        public string Creator { get; set; }
        public string ThumbUrl { get; set; }
    }
}
