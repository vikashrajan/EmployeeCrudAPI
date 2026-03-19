using Microsoft.EntityFrameworkCore;
using EmployeeCrud.API.Models;

namespace EmployeeCrud.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
