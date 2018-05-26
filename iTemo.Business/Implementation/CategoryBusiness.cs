using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using iTemo.Business.Interface;
using iTemo.Business.Model;
using iTemo.Core.Model;
using iTemo.Data.Repository.Interface;
using iTemo.jsGrid;

namespace iTemo.Business.Implementation
{
    public class CategoryBusiness : BaseBusiness, ICategoryBusiness
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryBusiness(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseResult<GridResponse<CategoryListingBusinessModel>>> Search(SearchCriteriaModel model, GridSettings gridSettings)
        {
            var items = from p in _categoryRepository.GetAllNonDelete()
                select new CategoryListingBusinessModel
                {
                    Id = p.Id,
                    Name = p.Name
                };

            if (!string.IsNullOrEmpty(model.Keyword))
            {
                items = items.Where(r => r.Name.Contains(model.Keyword));
            }

            var totalItems = await items.CountAsync();
            OrderBy(ref items, gridSettings);
            Paging(ref items, gridSettings);

            var results = new GridResponse<CategoryListingBusinessModel>(await items.ToListAsync(), totalItems);
            return new ResponseResult<GridResponse<CategoryListingBusinessModel>>(results, true);
        }
    }
}
