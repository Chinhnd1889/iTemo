using AutoMapper;
using iTemo.AutoMapperProfiles;

namespace iTemo
{
    public class AutoMapperConfig
    {
        public static void RegisterProfiles()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<WebToBusinessMappingProfile>();
                x.AddProfile<BusinessToWebMappingProfile>();
            });
        }
    }
}