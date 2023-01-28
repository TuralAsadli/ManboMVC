using MambaMVC1.Models;

namespace MambaMVC1.Abstractions.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        IEnumerable<Employee> GetAllWithPosition();
    }
}
