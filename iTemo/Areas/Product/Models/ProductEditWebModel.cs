using System.ComponentModel.DataAnnotations;
using iTemo.Core;

namespace iTemo.Areas.Product.Models
{
    public class ProductEditWebModel
    {
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = Constants.Messages.CommonMsg005)]
        public string Name { get; set; }

        [Display(Name = "Mã")]
        public string Code { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        [Display(Name = "Số lượng")]
        public int? Qty { get; set; }

        [Display(Name = "Danh mục")]
        public int? CategoryId { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public int? SupplierId { get; set; }
    }
}