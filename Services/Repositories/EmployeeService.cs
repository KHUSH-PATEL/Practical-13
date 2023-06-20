using Practical_13.Data;
using Practical_13.Models;
using Practical_13.Services.Interface;

namespace Practical_13.Services.Repositories
{
    public class EmployeeService : IEmployee
    {
        private readonly AuthDbContext _context;

        public EmployeeService(AuthDbContext context)
        {
            this._context = context;
        }
        public List<EmployeeTest1> GetEmployees()
        {
            var data = _context.EmployeeTests.ToList();
            return data;
        }        
        public EmployeeTest1 GetSingleEmployee(int id)
        {
            var data = _context.EmployeeTests.Find(id);
            return data;
        }
        public void AddOrUpdateEmployee(int id, EmployeeTest1 employeeData)
        {
            var data = GetSingleEmployee(id);
            if (data != null)
            {
                data.Name = employeeData.Name;
                data.Age = employeeData.Age;
                data.DOB = employeeData.DOB;
                _context.SaveChanges();
            }
            else
            {
                _context.EmployeeTests.Add(employeeData);
                _context.SaveChanges();
            }
        }
        public void RemoveEmployee(int id)
        {
            var data = GetSingleEmployee(id);
            _context.EmployeeTests.Remove(data);
            _context.SaveChanges();
        }
    }
}
