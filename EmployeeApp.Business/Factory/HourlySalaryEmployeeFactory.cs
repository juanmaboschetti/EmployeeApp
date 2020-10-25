using EmployeeApp.Business.Models;

namespace EmployeeApp.Business.Factory
{
    public class HourlySalaryEmployeeFactory : EmployeeFactory
    {
        private readonly int _id;
        private readonly double _hourlySalary;
        private readonly string _name;
        private readonly int _roleId;
        private readonly string _roleName;
        private readonly string _roleDescription;
        public HourlySalaryEmployeeFactory(int id, double hourlySalary, string name, int roleId, string roleDescription, string roleName)
        {
            this._id = id;
            this._hourlySalary = hourlySalary;
            this._name = name;
            this._roleId = roleId;
            this._roleDescription = roleDescription;
            this._roleName = roleName;
        }
        public override IEmployee GetEmployee()
        {
            return new HourlySalaryEmployee(_id, _hourlySalary, _name, _roleId, _roleDescription, _roleName );
        }
    }
}
