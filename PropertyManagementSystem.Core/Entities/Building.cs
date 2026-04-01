namespace PropertyManagementSystem.Core.Entities
{
    public class Building
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int Floors { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}