namespace PropertyManagementSystem.Core.Entities
{
    public class Tenant
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; } = null!;
    }
}