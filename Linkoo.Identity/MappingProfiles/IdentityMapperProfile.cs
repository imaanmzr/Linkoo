using AutoMapper;
using Linkoo.Application.Common.Models.Identity;

namespace Linkoo.Identity.MappingProfiles
{
    public class IdentityMapperProfile : Profile
    {
        public IdentityMapperProfile()
        {
            CreateMap<RegistrationRequest, RegistrationResponse>();
        }
    }
}