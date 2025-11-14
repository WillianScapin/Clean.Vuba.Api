using MediatR;

namespace Vuba.Application.UseCases.Account.GetAllAccount
{
    public sealed record GetAllAccountRequest :
                            IRequest<List<GetAllAccountResponse>>;
}
