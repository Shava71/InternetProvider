namespace InternetProvider
{
    public class ClientPayment
    {
        public int ClientId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public DateOnly Date { get; set; }
    }
}
