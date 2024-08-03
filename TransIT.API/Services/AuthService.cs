using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using TransIT.Domain.Models.Users;
using TransIT.Infrastructure;
using TransIT.Infrastructure.Migrations;

namespace TransIT.API.Services
{
    public class AuthService
    {
        private readonly TransITContext context;

        public AuthService(TransITContext context)
        {
            this.context = context;
        }

        public async Task<Employee?> Authenticate(Employee employee)
        {
            var emp = await context.Employees.FirstOrDefaultAsync(e => e.Username == employee.Username);
            if(emp == null) { return null; }
            else
            {
                var isPassword = BCrypt.Net.BCrypt.Verify(employee.Password, emp.Password);
                if (!isPassword)
                {
                    return null;
                }
            }
            return emp;
        }
        public async Task<Client?> AuthenticateClient(Client client)
        {
            var emp = await context.Clients.FirstOrDefaultAsync(e => e.Username == client.Username);
            if (emp == null) { return null; }
            else
            {
                var isPassword = BCrypt.Net.BCrypt.Verify(client.Password, emp.Password);
                if (!isPassword)
                {
                    return null;
                }
            }
            return emp;
        }
        public async Task<Employee> Register(Employee employee)
        {
            employee.Password = BCrypt.Net.BCrypt.HashPassword(employee.Password);
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return employee;
        }
        public async Task<Client> RegisterClient(Client employee)
        {
            employee.Password = BCrypt.Net.BCrypt.HashPassword(employee.Password);
            await context.Clients.AddAsync(employee);
            await context.SaveChangesAsync();
            return employee;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await context.Employees.ToListAsync();
        }


    }
}
