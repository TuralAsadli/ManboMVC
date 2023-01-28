using AutoMapper;
using MambaMVC1.Abstractions.Repositories;
using MambaMVC1.Abstractions.Services;
using MambaMVC1.Areas.ViewModel.Employee;
using MambaMVC1.Models;
using MambaMVC1.Utilites;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MambaMVC1.Services
{
    
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _db;
        IWebHostEnvironment _env;

        public EmployeeService(IWebHostEnvironment env, IEmployeeRepository db)
        {
            _env = env;
            _db = db;
        }

        public void Create(CreateEmployeeVM employeeVM)
        {
            employeeVM.Img.CreateFile(Path.Combine(_env.WebRootPath, "assets", "img", "img", employeeVM.Img.ChangeFileName()));

            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<CreateEmployeeVM, Employee>()
                );
            var mapper = new Mapper(config);
            var employee = mapper.Map<Employee>(employeeVM);

            employee.ImgName = employeeVM.Img.ChangeFileName();

            _db.Create(employee);
            
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public Employee EmployeeGetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> getAllWithPosition()
        {
            throw new NotImplementedException();
        }

        public void Update(EmployeeUpdateVM updateVM)
        {
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<EmployeeUpdateVM, Employee>()
                );
            var mapper = new Mapper(config);
            var employee = mapper.Map<Employee>(updateVM);
            updateVM.Img.CreateFile(Path.Combine(_env.WebRootPath, "assets", "img", "img", updateVM.Img.ChangeFileName()));

            employee.ImgName = updateVM.Img.ChangeFileName();


            _db.Update(employee);
        }
    }
}
