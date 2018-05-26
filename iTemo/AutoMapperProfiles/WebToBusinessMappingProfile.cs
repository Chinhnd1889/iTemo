using AutoMapper;
using iTemo.Business.Model;
using iTemo.Models;

namespace iTemo.AutoMapperProfiles
{
    public class WebToBusinessMappingProfile : Profile
    {
        public WebToBusinessMappingProfile()
        {
            CreateMap<SearchCriteriaRequest, SearchCriteriaModel>();
        }
    }
}