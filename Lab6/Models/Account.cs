namespace Lab6.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateAccountOpened { get; set; }
        public string AccountName { get; set; }
        public string OtherAccountDetails { get; set; }

        public Customer Customer { get; set; }
        public List<FinancialTransaction> FinancialTransactions { get; set; }
    }
}
