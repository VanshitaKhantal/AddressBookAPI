using AutoMapper;
using ModelLayer;
using ModelLayer.DTO;
using ModelLayer.Model;

namespace BusinessLayer.Mappings
{
    /// <summary>
    /// AutoMapper profile for mapping between AddressBookEntry and AddressBookEntryDTO.
    /// </summary>
    public class AddressBookMappingProfile : Profile
    {
        public AddressBookMappingProfile()
        {
            CreateMap<AddressBookEntry, AddressBookEntryDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
                .ReverseMap();
        }
    }
}