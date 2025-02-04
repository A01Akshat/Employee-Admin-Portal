
namespace EmployeeAdminPortal.Models
{
    public class AddEmployeeDto
    {
        public required string Name { get; set; }

        public required string Email { get; set; }

        public string? Phone { get; set; } //? to say that its a nullable property

        public decimal Salary { get; set; }
    }
}
