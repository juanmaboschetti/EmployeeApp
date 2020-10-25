namespace EmployeeApp.Business.Models
{
    public interface IEmployee
    {
        int Id { get; set; }
        string Name { get; set; }
        int RoleId { get; set; }
        string RoleName { get; set; }
        string RoleDescription { get; set; }
        double HourlySalary { get; set; }
        double MonthlySalary { get; set; }
        double AnualSalary { get; set; }

    }
}
