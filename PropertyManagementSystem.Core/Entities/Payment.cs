namespace PropertyManagementSystem.Core.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public int TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}