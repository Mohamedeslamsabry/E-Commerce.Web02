using AutoMapper;
using Domain_Layer.Models.Identity;
using Shared.DTO.Identity;

namespace Service_Implemention.Profiles
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}
