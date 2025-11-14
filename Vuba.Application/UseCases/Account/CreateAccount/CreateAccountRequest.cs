using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Account.CreateAccount
{
    public sealed record CreateAccountRequest(string username, string email, string password)
                                                : IRequest<CreateAccountResponse>;
}
