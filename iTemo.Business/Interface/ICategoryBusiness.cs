using System.Threading.Tasks;
using iTemo.Business.Model;
using iTemo.Core.Model;
using iTemo.jsGrid;

namespace iTemo.Business.Interface
{
    public interface ICategoryBusiness
    {
        Task<ResponseResult<GridResponse<CategoryListingBusinessModel>>> Search(SearchCriteriaModel model, GridSettings gridSettings);
    }
}
