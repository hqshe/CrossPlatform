namespace Lab6.Models
{
    public class InvoiceLineItem
    {
        public int InvoiceLineItemId { get; set; }
        public int InvoiceNumber { get; set; }
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal DerivedProductCost { get; set; }
        public decimal DerivedVatPayable { get; set; }
        public decimal DerivedTotalCost { get; set; }
        public string OtherLineItemDetails { get; set; }

        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
    }
}
