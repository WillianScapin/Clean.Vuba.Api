using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Login.CreateLogin
{
    public sealed record CreateLoginRequest(string Email, string Password)
                            : IRequest<CreateLoginResponse>;
}
