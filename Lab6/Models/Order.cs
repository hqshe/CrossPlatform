namespace Lab6.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateOrderPlaced { get; set; }
        public string OrderDetails { get; set; }

        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public Invoice Invoice { get; set; }
    }
}
