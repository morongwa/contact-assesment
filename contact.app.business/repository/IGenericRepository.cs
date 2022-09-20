using System;
namespace contact.app.business.repository
{
    public interface IGenericRepository<T>: IDisposable
    {
        void Create(T obj, int? iCreatedById);
        void Update(T obj);
        void Delete(int id);
        IEnumerable<T> All();
        IEnumerable<T> Filter(Func<T, bool> func);
        T GetById(int id);
        void Save();
    }
}

