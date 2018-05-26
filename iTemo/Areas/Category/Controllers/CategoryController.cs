using AutoMapper;
using iTemo.Areas.Category.Models;
using iTemo.Business.Interface;
using iTemo.Business.Model;
using iTemo.Core.Model;
using iTemo.jsGrid;
using iTemo.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace iTemo.Areas.Category.Controllers
{
    public class CategoryController : Controller
    {
        #region Private Variables 

        private readonly ICategoryBusiness _categoryBusiness;

        #endregion

        #region Constructors

        public CategoryController(ICategoryBusiness categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }

        #endregion

        public ActionResult Index()
        {
            var model = new CategorySearchViewModel
            {
                CategoryGrid = GenerateCategoryListingGrid()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Search(SearchCriteriaRequest model, GridSettings gridSettings)
        {
            var result = await ExecuteSearch(model, gridSettings);
            if (!result.IsSuccess)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var response = Mapper.Map<GridResponse<CategoryListingWebModel>>(result.Data);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        #region Private Methods

        private async Task<ResponseResult<GridResponse<CategoryListingBusinessModel>>> ExecuteSearch(SearchCriteriaRequest model, GridSettings gridSettings)
        {
            if (string.IsNullOrEmpty(gridSettings.SortField))
            {
                gridSettings.SortField = "Name";
            }
            var request = Mapper.Map<SearchCriteriaModel>(model);
            return await _categoryBusiness.Search(request, gridSettings);
        }

        private Grid GenerateCategoryListingGrid()
        {
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);

            return new Grid("gridCategoryListing")
                .SetMode(GridMode.Listing)
                .SetWidth("100%")
                .SetSorting(true)
                .SetPaging(true)
                .SetPageSize(10)
                .SetSelected(true)
                .SetPageLoading(true)
                .SetAutoload(true)
                .OnDataLoaded("onDataLoaded")
                .SetSearchUrl(urlHelper.Action("Search", "Category", new { Area = "Category" }))
                .SetDefaultSorting("Name", SortOrder.Asc)
                .SetFields(
                    new Field("Id")
                        .SetVisible(false),
                    new Field("Name")
                        .SetTitle("Tên danh mục")
                        .SetWidth(20)
                        .SetAlign(Align.Left)
                );
        }

        #endregion
    }
}