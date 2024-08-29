using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Rating.GetAllRating
{
    public sealed class GetAllRatingResponse
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
        public string ContentType { get; set; }
        public int UserId { get; set; }
        public int Score { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
