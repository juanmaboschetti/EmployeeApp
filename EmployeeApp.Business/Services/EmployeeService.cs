using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeApp.Business.Factory;
using EmployeeApp.Business.Models;
using EmployeeApp.Data;
using EmployeeApp.Data.Models;

namespace EmployeeApp.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public async Task<IEmployee> GetEmployee(int Id)
        {
            var response = await this._employeeRepository.GetEmployeeList();
            var employee = response.FirstOrDefault(x => x.Id == Id);
            if(employee != null)
            {
                var factory = GetEmployeeFactory(employee);
                return factory.GetEmployee();
            }
            return null;
        }

        public async Task<IEnumerable<IEmployee>> GetEmployees()
        {
            var employeesList = new List<IEmployee>();
            foreach(var employee in await this._employeeRepository.GetEmployeeList())
            {
                var factory = GetEmployeeFactory(employee);
                employeesList.Add(factory.GetEmployee());           
            }
            return employeesList;
        }

        private EmployeeFactory GetEmployeeFactory(Employee employee)
        {
            switch (employee.ContractTypeName)
            {
                case ContractType.HourlySalaryEmployee:
                    return new HourlySalaryEmployeeFactory(employee.Id, employee.HourlySalary, employee.Name, employee.RoleId, employee.RoleDescription, employee.RoleName);
                case ContractType.MonthlySalaryEmployee:
                    return new MonthlySalaryEmployeeFactory(employee.Id, employee.MonthlySalary, employee.Name, employee.RoleId, employee.RoleDescription, employee.RoleName);
                default:
                    throw new ApplicationException("ContractType is not supported");
            }
        }
    }
}
