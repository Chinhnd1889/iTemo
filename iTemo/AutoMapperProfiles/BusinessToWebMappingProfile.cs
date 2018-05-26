using AutoMapper;
using iTemo.Areas.Category.Models;
using iTemo.Areas.Product.Models;
using iTemo.Business.Model;
using iTemo.Core.Model;
using iTemo.jsGrid;

namespace iTemo.AutoMapperProfiles
{
    public class BusinessToWebMappingProfile : Profile
    {
        public BusinessToWebMappingProfile()
        {
            CreateMap(typeof(ResponseResult<>), typeof(ResponseResult<>));
            CreateMap(typeof(GridResponse<>), typeof(GridResponse<>));

            #region Product

            CreateMap<ProductListingBusinessModel, ProductListingWebModel>();
            CreateMap<ProductEditBusinessModel, ProductEditWebModel>();

            #endregion

            #region Category

            CreateMap<CategoryListingBusinessModel, CategoryListingWebModel>();

            #endregion
        }
    } 
}