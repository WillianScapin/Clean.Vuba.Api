using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Profile.CreateProfile
{
    public sealed class CreateProfileResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileUrl { get; set; }
        public int AccountId { get; set; }
        public bool IsChildProfile { get; set; }
        public bool IsActive { get; set; }
    }
}
