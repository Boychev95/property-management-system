namespace PropertyManagementSystem.Core.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Floors { get; set; }
        public ICollection<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}