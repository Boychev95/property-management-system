namespace PropertyManagementSystem.Core.Entities
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public int Floor { get; set; }

        public int BuildingId { get; set; }
        public Building? Building { get; set; }

        public ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();
    }
}