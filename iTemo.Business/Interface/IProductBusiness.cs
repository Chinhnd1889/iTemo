using iTemo.Business.Model;
using iTemo.jsGrid;
using System.Threading.Tasks;
using iTemo.Core.Model;

namespace iTemo.Business.Interface
{
    public interface IProductBusiness
    {
        Task<ResponseResult<GridResponse<ProductListingBusinessModel>>> Search(SearchCriteriaModel model, GridSettings gridSettings);
        Task<ResponseResult<ProductEditBusinessModel>> GetItemById(int id);
    }
}
