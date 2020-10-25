using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeApp.Business.Models;

namespace EmployeeApp.Business.Services
{
    public interface IEmployeeService
    {
        public Task<IEnumerable<IEmployeeDto>> GetEmployees();

        public Task<IEmployeeDto> GetEmployee(int Id);
    }
}
