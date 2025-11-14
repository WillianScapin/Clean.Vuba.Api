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
    public sealed class Episode : BaseEntity
    {
        public Episode() { }
        public Episode(string title, int episodeNumber, string synopsis, DateTime releaseDate, string serieUrl, string fileKey, int duration, string thumbUrl, int seasonId)
        {
            this.Title = title;
            this.EpisodeNumber = episodeNumber;
            this.Synopsis = synopsis;
            this.ReleaseDate = releaseDate;
            this.SerieUrl = serieUrl;
            this.FileKey = fileKey;
            this.Duration = duration;
            this.ThumbUrl = thumbUrl;
            this.SeasonId = seasonId;

            this.Validate();
        }

        public string Title { get; set; }
        public int EpisodeNumber { get; set; }
        public string Synopsis { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string SerieUrl { get; set; }
        public string FileKey { get; set; }
        public int Duration { get; set; }
        public string ThumbUrl { get; set; }
        public int SeasonId { get; set; }



        public Season Season { get; set; }





        bool Validate()
        {
            var validator = new EpisodeValidator();
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
