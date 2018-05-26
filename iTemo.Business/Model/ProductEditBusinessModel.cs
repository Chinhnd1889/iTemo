namespace iTemo.Business.Model
{
    public class ProductEditBusinessModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? Qty { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
    }
}
