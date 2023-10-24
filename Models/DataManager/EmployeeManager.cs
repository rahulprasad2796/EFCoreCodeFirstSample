using EFCoreCodeFirstSample.Models.Repository;
using System.Linq;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        readonly EmployeeContext _context;
        public EmployeeManager(EmployeeContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
        public Employee Get(long id)
        {
            return _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Update(Employee employeeToUpdate, Employee employee)
        {
            employeeToUpdate.FirstName = employee.FirstName;
            employeeToUpdate.LastName = employee.LastName;
            employeeToUpdate.Email = employee.Email;
            employeeToUpdate.DateOfBirth = employee.DateOfBirth;
            employeeToUpdate.PhoneNumber = employee.PhoneNumber;

            _context.Employees.Update(employeeToUpdate);
            _context.SaveChanges();
        }
        public void Delete(Employee employee)
        {
            _context.Remove(employee);
            _context.SaveChanges();
        }
    }
}
