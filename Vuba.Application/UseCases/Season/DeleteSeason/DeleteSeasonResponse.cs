using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Season.DeleteSeason
{
    public sealed class DeleteSeasonResponse
    {
        public int Id { get; set; }
        public int SerieId { get; set; }
        public string Name { get; set; }
    }
}
