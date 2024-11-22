namespace Lab6.Models
{
    public class TransactionType
    {
        public string TransactionTypeCode { get; set; }
        public string TransactionTypeDescription { get; set; }

        public List<FinancialTransaction> FinancialTransactions { get; set; }
    }
}
