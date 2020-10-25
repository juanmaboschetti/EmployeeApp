namespace EmployeeApp.Business.Models
{
    class MonthlySalaryEmployeeDto : IEmployeeDto
    {
        public MonthlySalaryEmployeeDto(int id, double monthlySalary, string name, int roleId, string roleDescription, string roleName)
        {
            this.Id = id;
            this.Name = name;
            this.RoleId = roleId;
            this.RoleDescription = roleDescription;
            this.RoleName = roleName;
            this.MonthlySalary = monthlySalary;
            this.AnualSalary = monthlySalary * 12;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double HourlySalary { get; set; }
        public double MonthlySalary { get; set; }
        public double AnualSalary { get; set; }
    }
}
