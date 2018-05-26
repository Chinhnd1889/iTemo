using iTemo.Business.Interface;
using iTemo.Business.Model;
using iTemo.Core;
using iTemo.Core.Model;
using iTemo.Data.Infrastructure;
using iTemo.jsGrid;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace iTemo.Business.Implementation
{
    public class ProductBusiness : BaseBusiness, IProductBusiness
    {
        private readonly IiTemoUnitOfWork _iTemoUnitOfWork;

        public ProductBusiness(IiTemoUnitOfWork iTemoUnitOfWork)
        {
            _iTemoUnitOfWork = iTemoUnitOfWork;
        }

        public async Task<ResponseResult<ProductEditBusinessModel>> GetItemById(int id)
        {
            var item = await _iTemoUnitOfWork.ProductRepository.GetAsync(id);
            if (item == null)
            {
                return new ResponseResult<ProductEditBusinessModel>(null, false, Constants.Messages.CommonMsg001);
            }

            var result = new ProductEditBusinessModel()
            {
                Id = item.Id,
                Description = item.Description,
                SupplierId = item.SupplierId,
                Code = item.Code,
                Status = item.Status,
                CategoryId = item.CategoryId,
                Qty = item.Qty,
                Name = item.Name
            };
            return new ResponseResult<ProductEditBusinessModel>(result, true);
        }

        public async Task<ResponseResult<GridResponse<ProductListingBusinessModel>>> Search(SearchCriteriaModel model, GridSettings gridSettings)
        {
            var items = from p in _iTemoUnitOfWork.ProductRepository.GetAll()
                join c in _iTemoUnitOfWork.CategoryRepository.GetAllNonDelete()
                    on p.CategoryId equals c.Id into data
                from item in data.DefaultIfEmpty()
                select new ProductListingBusinessModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Code = p.Code,
                    Description = p.Description,
                    Qty = p.Qty,
                    Status = p.Status,
                    Category = item.Name,
                    IsDeleted = p.IsDeleted,
                    CreatedById = p.CreatedById
                };

            switch (model.ViewName)
            {
                case Constants.ProductViewType.InActiveProducts:
                    items = items.Where(r => r.IsDeleted);
                    break;
                case Constants.ProductViewType.MyProducts:
                    items = items.Where(r => r.CreatedById != null);
                    break;
                case Constants.ProductViewType.AllProducts:
                    items = items.Where(r => !r.IsDeleted);
                    break;
                default:
                    items = items.Where(r => !r.IsDeleted);
                    break;
            }   

            if (!string.IsNullOrEmpty(model.Keyword))
            {
                items = items.Where(r => r.Name.Contains(model.Keyword) ||
                                         r.Description.Contains(model.Keyword) ||
                                         r.Code.Contains(model.Keyword) ||
                                         r.Status.Contains(model.Keyword) ||
                                         r.Category.Contains(model.Keyword));
            }

            var totalItems = await items.CountAsync();
            OrderBy(ref items, gridSettings);
            Paging(ref items, gridSettings);

            var results = new GridResponse<ProductListingBusinessModel>(await items.ToListAsync(), totalItems);
            return new ResponseResult<GridResponse<ProductListingBusinessModel>>(results, true);
        }
    }
}
