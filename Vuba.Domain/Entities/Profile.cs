using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Exceptions;
using Vuba.Domain.Validators;

namespace Vuba.Domain.Entities
{
    public sealed class Profile : BaseEntity
    {
        //COnstrutor padrão para o automapper
        public Profile() { }

        public Profile(string name, string profileUrl, int accountId, bool isChildProfile, bool isActive)
        {
            this.Name = name;
            this.ProfileUrl = profileUrl;
            this.AccountId = accountId;
            this.IsChildProfile = isChildProfile;
            this.IsActive = isActive;

            this.Validate();
        }

        public string Name { get; set; }
        public string ProfileUrl { get; set; }
        public int AccountId { get; set; }
        public bool IsChildProfile { get; set; }
        public bool IsActive { get; set; }

        public Account Account { get; set; }



        bool Validate()
        {
            var validator = new ProfileValidator();
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
