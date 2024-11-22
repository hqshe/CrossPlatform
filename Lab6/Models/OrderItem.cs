namespace Lab6.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public string OtherOrderItemDetails { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
        public InvoiceLineItem InvoiceLineItem { get; set; }
    }
}
