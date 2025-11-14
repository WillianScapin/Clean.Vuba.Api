namespace Vuba.Application.UseCases.Profile.UpdateProfile
{
    public sealed class UpdateProfileResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileUrl { get; set; }
        public int AccountId { get; set; }
        public bool IsChildProfile { get; set; }
        public bool IsActive { get; set; }
    }
}
