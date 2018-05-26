using iTemo.Business.Interface;
using iTemo.Business.Model;
using iTemo.Core.Model;
using iTemo.jsGrid;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using iTemo.Areas.Product.Models;
using iTemo.Models;

namespace iTemo.Areas.Product.Controllers
{
    public class ProductController : Controller
    {
        #region Private Variables 

        private readonly IProductBusiness _productBusiness;

        #endregion

        #region Constructors

        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        #endregion

        public ActionResult Index()
        {
            var model = new ProductSearchViewModel
            {
                ProductGrid = GenerateProductListingGrid()
            };
            return View(model);
        }

        public ActionResult CreateProduct()
        {
            return View("DetailProduct");
        }

        public async Task<ActionResult> DetailProduct(int id)
        {
            var result = await _productBusiness.GetItemById(id);
            var model = Mapper.Map<ProductEditWebModel>(result.Data);
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

            var response = Mapper.Map<GridResponse<ProductListingWebModel>>(result.Data);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        #region Private Methods

        private async Task<ResponseResult<GridResponse<ProductListingBusinessModel>>> ExecuteSearch(SearchCriteriaRequest model, GridSettings gridSettings)
        {
            if (string.IsNullOrEmpty(gridSettings.SortField))
            {
                gridSettings.SortField = "Name";
            }
            var request = Mapper.Map<SearchCriteriaModel>(model);
            return await _productBusiness.Search(request, gridSettings);
        }

        private Grid GenerateProductListingGrid()
        {
            var urlHelper = new UrlHelper(ControllerContext.RequestContext);

            return new Grid("gridProductListing")
                .SetMode(GridMode.Listing)
                .SetWidth("100%")
                .SetSorting(true)
                .SetPaging(true)
                .SetPageSize(10)
                .SetSelected(true)
                .SetPageLoading(true)
                .SetAutoload(true)
                .OnDataLoaded("productModule.onDataLoaded")
                .SetSearchUrl(urlHelper.Action("Search", "Product", new { Area = "Product" }))
                .SetDefaultSorting("Name", SortOrder.Asc)
                .SetFields(
                    new Field("")
                        .SetWidth(10)
                        .SetItemTemplate("productModule.generateCheckBoxColumn")
                        .SetAlign(Align.Center)
                        .SetSorting(false),
                    new Field("Code")
                        .SetTitle("Mã")
                        .SetWidth(20)
                        .SetItemTemplate("productModule.generateProductCodeColumn")
                        .SetAlign(Align.Center),
                    new Field("Name")
                        .SetTitle("Tên sản phẩm")
                        .SetWidth(20)
                        .SetAlign(Align.Left),
                    new Field("Category")
                        .SetTitle("Danh mục")
                        .SetWidth(20)
                        .SetAlign(Align.Center),
                    new Field("Description")
                        .SetTitle("Mô tả")
                        .SetWidth(20)
                        .SetAlign(Align.Center),
                    new Field("Status")
                        .SetTitle("Trạng thái")
                        .SetWidth(20)
                        .SetAlign(Align.Center),
                    new Field("Qty")
                        .SetTitle("Số lượng")
                        .SetWidth(20)
                        .SetAlign(Align.Center),
                    new Field("SupplierId")
                        .SetTitle("Nhà cung cấp")
                        .SetWidth(20)
                        .SetAlign(Align.Center)
                );
        }

        #endregion
    }
}