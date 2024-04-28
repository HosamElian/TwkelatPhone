using AutoMapper;
using Twkelat.Mobile.Models.Response;
using Twkelat.Mobile.Models.ViewModels;

namespace Twkelat.Mobile.SD
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<IEnumerable<DelegationResponse>, IEnumerable<DelegationVM>>().ReverseMap();
            //CreateMap<List<DelegationResponse>,List<DelegationVM> >()
            //    .ForMember(d=>d.Color, opt => opt.MapFrom( o=>  o.ExpirationDate < DateTime.Today ? "#008800": "#FF0000"))
            //    .ReverseMap();
        }
    }
}
