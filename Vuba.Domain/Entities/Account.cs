using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using Vuba.Domain.Exceptions;
using Vuba.Domain.Validators;

namespace Vuba.Domain.Entities
{
    public sealed class Account : BaseEntity
    {
        public Account() { }
        public Account(string username, string email, string password)
        {
            this.Username = username;
            this.Email = email;
            this.Password = password;

            this.Validate();
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Profile> profiles { get; set; }


        bool Validate()
        {
            var validator = new AccountValidator();
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
