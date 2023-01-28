using MambaMVC1.Areas.ViewModel.Employee;
using MambaMVC1.Models;

namespace MambaMVC1.Abstractions.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee EmployeeGetById(int id);
        void Create(CreateEmployeeVM employeeVM);
        void Update(EmployeeUpdateVM employeeVM);
        IEnumerable<Employee> getAllWithPosition();
        void Delete(int id);
        void DeleteAll();
    }
}
