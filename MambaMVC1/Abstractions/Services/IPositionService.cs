using MambaMVC1.Areas.ViewModel.Employee;
using MambaMVC1.Areas.ViewModel.Position;
using MambaMVC1.Models;

namespace MambaMVC1.Abstractions.Services
{
    public interface IPositionService
    {
        IEnumerable<Position> GetAll();
        Position Get(int id);
        void Create(CreatePositionVM possitionVM);
        void Update(CreatePositionVM possitionVM);
       
        void Delete(int id);
        void DeleteAll();
    }
}
