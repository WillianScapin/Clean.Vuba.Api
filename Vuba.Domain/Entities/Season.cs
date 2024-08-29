using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Exceptions;
using Vuba.Domain.Validators;

namespace Vuba.Domain.Entities
{
    public sealed class Season : BaseEntity
    {
        public Season() { }
        public Season(string name, int serieId)
        {
            Name = name;
            SerieId = serieId;

            this.Validate();
        }

        public string Name { get; set; }
        public int SerieId { get; set; }

        public Serie Serie { get; set; }
        public List<Episode> Episodes { get; set; }



        bool Validate()
        {
            var validator = new SeasonValidator();
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
