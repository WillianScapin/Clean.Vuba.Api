namespace Vuba.Application.UseCases.Profile.GetAllProfile
{
    public sealed class GetAllProfileResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileUrl { get; set; }
        public int AccountId { get; set; }
        public bool IsChildProfile { get; set; }
        public bool IsActive { get; set; }
    }
}
