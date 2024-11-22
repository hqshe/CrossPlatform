namespace Lab6.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductionTypeCode { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }
        public string OtherProductDetails { get; set; }

        public ProductType ProductType { get; set; }
    }
}
