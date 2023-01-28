using MambaMVC1.Abstractions.Repositories;
using MambaMVC1.DAL;
using MambaMVC1.Models;

namespace MambaMVC1.Repository
{
    public class PositionRepository : IPositionRepository
    {
        ManbaDbContext _db;

        public PositionRepository(ManbaDbContext db)
        {
            _db = db;
        }

        public void Create(Position item)
        {
            if (item == null)
            {
                return;
            }
            _db.Positions.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var res = _db.Positions.FirstOrDefault(x => x.Id == id);
            if (res != null)
            {
                _db.Positions.Remove(res);
                Save();
            }
        }

        public Position Get(int id)
        {
            return _db.Positions.FirstOrDefault(x => x.Id == id) as Position;
            
        }

        public IEnumerable<Position> GetAll()
        {
            return _db.Positions;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Position item)
        {
            if (item == null)
            {
                return;
            }
            _db.Positions.Update(item);
            Save();
        }
    }
}
