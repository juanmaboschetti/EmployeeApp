using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Xunit;
using Shouldly;
using EmployeeApp.Data;
using EmployeeApp.Data.Models;
using EmployeeApp.Business.Services;
using System;

namespace EmployeeApp.UnitTests
{
    public class EmployeeServiceTest
    {
        [Fact]
        public async void EmployeeServiceShouldReturnAValidEmployee()
        {
            //Arrange
            var employeeRepositoryMoq = Substitute.For<IEmployeeRepository>();
            employeeRepositoryMoq.GetEmployeeList().Returns(mock =>
            {
                var mockEmployeeList = new List<Employee>();
                mockEmployeeList.Add(new Employee
                {
                    Id = 1,
                    ContractTypeName = ContractType.HourlySalaryEmployee,
                    Name = "Julian",
                    RoleDescription = null,
                    RoleId = 1,
                    RoleName = "Contractor",
                    HourlySalary = 8000.0,
                    MonthlySalary = 800000.0
                });
                return mockEmployeeList;
            });

            var sut = new EmployeeService(employeeRepositoryMoq);

            //Act
            var employees = await sut.GetEmployees();

            //Assert
            var employee = employees.FirstOrDefault();
            employees.ShouldNotBeEmpty();
            employee.AnualSalary.ShouldBe(120 * employee.HourlySalary * 12);
        }

        [Fact]
        public  void EmployeeServiceShouldThrowAnException()
        {
            //Arrange
            var employeeRepositoryMoq = Substitute.For<IEmployeeRepository>();
            employeeRepositoryMoq.GetEmployeeList().Returns(mock =>
            {
                var mockEmployeeList = new List<Employee>();
                mockEmployeeList.Add(new Employee
                {
                    Id = 1,
                    Name = "Julian",
                    RoleDescription = null,
                    RoleId = 1,
                    RoleName = "Contractor",
                    HourlySalary = 8000.0,
                    MonthlySalary = 800000.0
                });
                return mockEmployeeList;
            });

            var sut = new EmployeeService(employeeRepositoryMoq);

            //Act & Assert
            Should.Throw<ApplicationException>(async () => await sut.GetEmployees())
                .Message.ShouldBe("ContractType is not supported");
        }
    }
}
