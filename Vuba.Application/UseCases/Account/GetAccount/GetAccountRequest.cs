using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Account.GetAccount
{
    public sealed record GetAccountRequest(int id)
                                            : IRequest<GetAccountResponse>;
}
