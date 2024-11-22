namespace Lab6.Models
{
    public class FinancialTransaction
    {
        public int TransactionId { get; set; }
        public int AccountId { get; set; }
        public int InvoiceNumber { get; set; }
        public string TransactionTypeCode { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionComment { get; set; }
        public string OtherTransactionDetails { get; set; }

        public Account Account { get; set; }
        public Invoice Invoice { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
