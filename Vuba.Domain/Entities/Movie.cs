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
    public sealed class Movie : BaseEntity
    {
        public Movie() { }

        public Movie(string title, string synopsis, DateTime releaseYear, string ageGroup, string director, string movieUrl, string fileKey, int duration, string thumbUrl)
        {
            this.Title = title;
            this.Synopsis = synopsis;
            this.ReleaseYear = releaseYear;
            this.AgeGroup = ageGroup;
            this.Director = director;
            this.MovieUrl = movieUrl;
            this.FileKey = fileKey;
            this.Duration = duration;
            this.ThumbUrl = thumbUrl;


            this.Validate();
        }

        public string Title { get; set; }
        public string Synopsis { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string AgeGroup { get; set; }
        public string Director { get; set; }
        public string MovieUrl { get; set; }
        public string FileKey { get; set; }
        public int Duration { get; set; }
        public string ThumbUrl { get; set; }
        

        //Muitos para muitos
        public ICollection<Genre> Genre { get; set; }

        public ICollection<Rating> Rating { get; set; }



        bool Validate()
        {
            var validator = new MovieValidator();
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
