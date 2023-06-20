using Practical_13.Models;

namespace Practical_13.Services.Interface
{
    public interface IEmployee
    {
        EmployeeTest1 GetSingleEmployee(int id);
        List<EmployeeTest1> GetEmployees();
        void AddOrUpdateEmployee(int id, EmployeeTest1 employeeData);
        void RemoveEmployee(int id);
    }
}
