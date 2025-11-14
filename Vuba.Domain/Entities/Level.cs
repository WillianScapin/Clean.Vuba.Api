using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Exceptions;
using Vuba.Domain.Validators;

namespace Vuba.Domain.Entities
{
    public sealed class Level : BaseEntity
    {
        public Level() { }
        public Level(string name)
        {
            Name = name;

            this.Validate();
        }

        public string Name { get; set; }

        public List<Serie> Series { get; set; }



        bool Validate()
        {
            var validator = new LevelValidator();
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
