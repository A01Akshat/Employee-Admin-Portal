using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allemployees= dbContext.Employees.ToList();
            return Ok(allemployees);
        }

        [HttpGet]

        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id) {

            var employee=dbContext.Employees.Find(id); 

            if(employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]

        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var EmployeeEntity = new Employee()
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };


            dbContext.Employees.Add(EmployeeEntity);
            dbContext.SaveChanges();
            return Ok(EmployeeEntity);
        }

        [HttpPut]

        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);

            if(employee is null)
            {
                return NotFound();
            }
            employee.Name = updateEmployeeDto.Name;
            employee.Phone = updateEmployeeDto.Phone;
            employee.Email = updateEmployeeDto.Email;
            employee.Salary = updateEmployeeDto.Salary;

            dbContext.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]

        [Route("{id:guid}")]

        public IActionResult Delete(Guid id)
        {
            var employee = dbContext.Employees.Find(id);

            if( employee is null)
            {
                return NotFound();
            }
            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();
            return Ok(employee);
        }
    }
}
