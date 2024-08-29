using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vuba.Application.UseCases.Account.UpdateUser;

namespace Vuba.Application.UseCases.Account.UpdateAccount
{
    public sealed record UpdateAccountRequest(int id, string username, string password, string email)
                                                : IRequest<UpdateAccountResponse>;
}
