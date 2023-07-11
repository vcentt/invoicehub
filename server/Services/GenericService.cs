
using Repository.Interfaces.IGenericRepository;
using Services.Interfaces.IGenericService;

namespace Services.GenericService;

public class GenericService<T> : IGenericService<T> where T:class {

    private readonly IGenericRepository<T> _context;
    public GenericService(IGenericRepository<T> context){
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.GetAll();
    }
    public async Task<T> AddNew(T entity)
    {
        return await _context.AddNew(entity);
    }
    public async Task<T> Update(T entity)
    {
        return await _context.Update(entity);
    }

    public async Task<T> Delete(int id)
    {
        return await _context.Delete(id);
    }

    public async Task<T> GetById(int id)
    {
        return await _context.GetById(id);
    }
}