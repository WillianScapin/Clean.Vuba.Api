using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Exceptions;
using Vuba.Domain.Validators;

namespace Vuba.Domain.Entities
{
    public sealed class Rating : BaseEntity
    {
        public Rating() { }
        public Rating(int contentId, string contentType, int userId, int score, DateTime timestamp)
        {
            ContentId = contentId;
            ContentType = contentType;
            UserId = userId;
            Score = score;
            Timestamp = timestamp;

            this.Validate();
        }

        public int ContentId { get; set; } // movie, series, or episode ID
        public string ContentType { get; set; } // 'movie', 'series', or 'episode'
        public int UserId { get; set; }
        public int Score { get; set; }
        public DateTime Timestamp { get; set; }


        bool Validate()
        {
            var validator = new RatingValidator();
            var result = validator.Validate(this);

            if (result.IsValid)
                return true;
            else
            {
                var errors = string.Join(Environment.NewLine, result.Errors);
                throw new EntityException(errors);
            }
        }


    }
}
