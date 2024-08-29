using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Login.CreateLogin
{
    public sealed class CreateLoginResponse
    {
        public int AccountId { get; set; }
        public string Token { get; set; }
    }
}
