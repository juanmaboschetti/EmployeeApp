using EmployeeApp.Business.Models;

namespace EmployeeApp.Business.Factory
{
    public class MonthlySalaryEmployeeFactory : EmployeeFactory
    {
        private readonly int _id;
        private readonly double _monthlySalary;
        private readonly string _name;
        private readonly int _roleId;
        private readonly string _roleName;
        private readonly string _roleDescription;
        public MonthlySalaryEmployeeFactory(int id, double monthlySalary, string name, int roleId, string roleDescription, string roleName)
        {
            this._id = id;
            this._monthlySalary = monthlySalary;
            this._name = name;
            this._roleId = roleId;
            this._roleDescription = roleDescription;
            this._roleName = roleName;
        }
        public override IEmployee GetEmployee()
        {
            return new MonthlySalaryEmployee(_id, _monthlySalary, _name, _roleId, _roleDescription, _roleName);
        }
    }
}
