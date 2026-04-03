using PropertyManagementSystem.Core.Entities;

namespace PropertyManagementSystem.Core.Entities;

public class Tenant
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public int ApartmentId { get; set; }
    public Apartment Apartment { get; set; }
}