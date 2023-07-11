

namespace Services.Interfaces.IGenericService;

public interface IGenericService<T> where T:class {
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> AddNew(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(int id);
}