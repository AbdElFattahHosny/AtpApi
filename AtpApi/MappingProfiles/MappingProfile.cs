using AtpApi.Dtos;
using AtpApi.Models;
using AutoMapper;

namespace AtpApi.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerDtos>().ReverseMap();
            CreateMap<Country, CountryDtos>().ReverseMap();
        }
    }
}
