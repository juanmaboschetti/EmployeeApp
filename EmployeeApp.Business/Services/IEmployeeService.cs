using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeApp.Business.Models;

namespace EmployeeApp.Business.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<IEmployee>> GetEmployees();

        public Task<IEmployee> GetEmployee(int Id);
    }
}
