using EmployeeCrud.API.Data;
using EmployeeCrud.API.Models;
using EmployeeCrud.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeCrud.Tests
{
    public class EmployeeServiceTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public async Task CreateEmployeeAsync_ShouldAddEmployee()
        {
            // Arrange
            var dbContext = GetDbContext();
            var service = new EmployeeService(dbContext);
            var newEmployee = new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Position = "Developer",
                Department = "IT"
            };

            // Act
            var createdEmployee = await service.CreateEmployeeAsync(newEmployee);

            // Assert
            Assert.NotEqual(0, createdEmployee.Id);
            Assert.Equal(1, dbContext.Employees.Count());
        }

        [Fact]
        public async Task GetAllEmployeesAsync_ShouldReturnAllEmployees()
        {
            // Arrange
            var dbContext = GetDbContext();
            dbContext.Employees.Add(new Employee { FirstName = "Jane", LastName = "Smith" });
            dbContext.Employees.Add(new Employee { FirstName = "Mark", LastName = "Taylor" });
            await dbContext.SaveChangesAsync();
            var service = new EmployeeService(dbContext);

            // Act
            var employees = await service.GetAllEmployeesAsync();

            // Assert
            Assert.Equal(2, employees.Count());
        }
    }
}
