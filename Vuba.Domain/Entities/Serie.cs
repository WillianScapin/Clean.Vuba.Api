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
    public sealed class Serie : BaseEntity
    {
        public Serie() { }
        public Serie(string title, DateTime? releaseYear, string description, string ageGroup, string creator, int? levelId)
        {
            this.Title = title;
            this.ReleaseYear = releaseYear;
            this.Description = description;
            this.AgeGroup = ageGroup;
            this.Creator = creator;
            this.LevelId = levelId;

            this.Validate();
        }

        public string Title { get; set; }
        public DateTime? ReleaseYear { get; set; }
        public string Description { get; set; }
        public string AgeGroup { get; set; }
        public string Creator { get; set; }
        public int? LevelId { get; set; }




        // Relationships
        public ICollection<Genre> Genre { get; set; }
        public ICollection<Season> Seasons { get; set; }
        public ICollection<Rating> Rating { get; set; }

        public Level Level { get; set; }


        bool Validate()
        {
            var validator = new SerieValidator();
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
