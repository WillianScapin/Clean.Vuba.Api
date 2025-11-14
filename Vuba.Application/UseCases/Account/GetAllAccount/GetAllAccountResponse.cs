using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Account.GetAllAccount
{
    public sealed record GetAllAccountResponse
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
