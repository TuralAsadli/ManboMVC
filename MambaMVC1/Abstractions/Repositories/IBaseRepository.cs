using MambaMVC1.Models.Base;

namespace MambaMVC1.Abstractions.Repositories
{
    public interface IBaseRepository<T> where T : BaseItem
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Create(T item);
        void Update(T item);
        void Delete(int id);

        void Save();
    }
}
