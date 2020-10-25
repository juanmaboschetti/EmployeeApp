using EmployeeApp.Business.Models;

namespace EmployeeApp.Business.Factory
{
    public abstract class EmployeeFactory
    {
        public abstract IEmployeeDto GetEmployee();
    }
}
