namespace Vuba.Application.UseCases.Account.CreateAccount
{
    public sealed class CreateAccountResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime DateCreate { get; set; }
        public string Token { get; set; }
    }

}
