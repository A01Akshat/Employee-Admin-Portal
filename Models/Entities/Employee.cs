namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }  //global unique identifier
        public required string Name { get; set; }

        public required string Email { get; set; }

        public string? Phone { get; set; } //? to say that its a nullable property

        public decimal Salary { get; set; }

    }
}
