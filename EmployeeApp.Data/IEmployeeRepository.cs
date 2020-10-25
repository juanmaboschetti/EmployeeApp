using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeApp.Data.Models;

namespace EmployeeApp.Data
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetEmployeeList();
    }
}
