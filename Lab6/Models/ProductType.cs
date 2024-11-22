namespace Lab6.Models
{
    public class ProductType
    {
        public string ProductionTypeCode { get; set; }
        public string ParentProductionTypeCode { get; set; }
        public string ProductTypeDescription { get; set; }
        public decimal VatRating { get; set; }

        public List<Product> Products { get; set; }
    }
}
