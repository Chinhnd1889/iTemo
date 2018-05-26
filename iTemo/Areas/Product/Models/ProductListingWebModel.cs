using System;

namespace iTemo.Areas.Product.Models
{
    public class ProductListingWebModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? Qty { get; set; }
        public string Category { get; set; }
        public string Supplier { get; set; }
    }
}