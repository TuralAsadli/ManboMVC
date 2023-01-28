using MambaMVC1.Abstractions.Repositories;
using MambaMVC1.DAL;
using MambaMVC1.Models;
using Microsoft.EntityFrameworkCore;

namespace MambaMVC1.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        ManbaDbContext _db;
        public void Create(Employee item)
        {
            if (item == null)
            {
                return;
            }
            _db.Employees.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var res = _db.Employees.FirstOrDefault(x => x.Id == id);
            if (res != null)
            {
                _db.Employees.Remove(res);
                Save();
            }
            
        }

        public Employee Get(int id)
        {
            return _db.Employees.FirstOrDefault(x=> x.Id == id) as Employee;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _db.Employees;
        }

        public IEnumerable<Employee> GetAllWithPosition()
        {
            return _db.Employees.Include(x => x.Position);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Employee item)
        {
            if (item == null)
            {
                return;
            }
            _db.Employees.Update(item);
            Save();
        }
    }
}
