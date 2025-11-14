using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Exceptions;
using Vuba.Domain.Validators;

namespace Vuba.Domain.Entities
{
    public sealed class Genre : BaseEntity
    {
        public Genre() { }

        public Genre(string name)
        {
            Name = name;

            this.Validate();
        }

        public string Name { get; set; }



        // Muitos para muitos
        public List<Movie> Movies { get; set; }
        public List<Serie> Series { get; set; }



        bool Validate()
        {
            var validator = new GenreValidator();
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
