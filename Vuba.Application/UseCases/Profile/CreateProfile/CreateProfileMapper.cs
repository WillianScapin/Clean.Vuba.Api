using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vuba.Application.UseCases.Profile.CreateProfile
{
    public sealed class CreateProfileMapper : AutoMapper.Profile
    {
        public CreateProfileMapper()
        {
            CreateMap<CreateProfileRequest, Domain.Entities.Profile>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ProfileUrl, opt => opt.MapFrom(src => src.ProfileUrl))
            .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId))
            .ForMember(dest => dest.IsChildProfile, opt => opt.MapFrom(src => src.IsChildProfile))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ConstructUsing(src => new Domain.Entities.Profile(src.Name, src.ProfileUrl, src.AccountId, src.IsChildProfile, src.IsActive));

            CreateMap<Domain.Entities.Profile, CreateProfileResponse>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ProfileUrl, opt => opt.MapFrom(src => src.ProfileUrl))
            .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.AccountId))
            .ForMember(dest => dest.IsChildProfile, opt => opt.MapFrom(src => src.IsChildProfile))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ConstructUsing(src => new CreateProfileResponse() 
            { 
                Id = src.Id,
                AccountId = src.AccountId,
                IsActive = src.IsActive,
                IsChildProfile = src.IsChildProfile,
                Name = src.Name,
                ProfileUrl = src.ProfileUrl
            });
        }
    }
}
