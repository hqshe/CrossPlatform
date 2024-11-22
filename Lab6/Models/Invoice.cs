namespace Lab6.Models
{
    public class Invoice
    {
        public int InvoiceNumber { get; set; }
        public int OrderId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string InvoiceDetails { get; set; }

        public Order Order { get; set; }
        public List<InvoiceLineItem> InvoiceLineItems { get; set; }
    }
}
