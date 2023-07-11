
using server.Models;

namespace Repository.Interfaces.IGenericRepository;

public interface IGenericRepository<T> where T:class {
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> AddNew(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(int id);
}