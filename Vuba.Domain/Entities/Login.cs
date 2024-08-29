using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Domain.Exceptions;
using Vuba.Domain.Validators;

namespace Vuba.Domain.Entities
{
    public sealed class Login : BaseEntity
    {
        public Login() { }
        public Login(string email, string password)
        {
            Email = email;
            Password = password;

            this.Validate();
        }

        public string Email { get; set; }
        public string Password { get; set; }


        bool Validate()
        {
            var validator = new LoginValidator();
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
