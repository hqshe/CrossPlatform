namespace Lab6.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string TownCity { get; set; }
        public string StateCountyProvince { get; set; }
        public string Country { get; set; }
        public string OtherDetails { get; set; }

        public List<Order> Orders { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
