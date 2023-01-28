using MambaMVC1.Abstractions.Repositories;
using MambaMVC1.Abstractions.Services;
using MambaMVC1.Areas.ViewModel.Position;
using MambaMVC1.Models;

namespace MambaMVC1.Services
{
    public class PositionService : IPositionService
    {
        IPositionRepository _db;

        public PositionService(IPositionRepository db)
        {
            _db = db;
        }

        public void Create(CreatePositionVM possitionVM)
        {
            Position position = new Position() { PositionName = possitionVM.PositionName };

            _db.Create(position);
            
        }

        public void Delete(int id)
        {
            _db.Delete(id);
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public Position Get(int id)
        {
            return _db.Get(id);
        }

        

        public IEnumerable<Position> GetAll()
        {
            return _db.GetAll();
        }

        
        public void Update(CreatePositionVM employeeVM)
        {
            Position res = new Position();
            res.PositionName = employeeVM.PositionName;

            _db.Update(res);

        }
    }
}
