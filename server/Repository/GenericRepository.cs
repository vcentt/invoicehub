
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.IGenericRepository;
using server.Models;

namespace Repository.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T:class {
    private readonly InvocehubContext _context;

    public GenericRepository(InvocehubContext context){
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        var query = from n in _context.Set<T>()
                    select n;

        return await query.ToListAsync();
    }

    public async Task<T> AddNew(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
    public async Task<T> Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> Delete(int id)
    {
        var entity = await GetById(id);
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> GetById(int id)
    {
       return await _context.Set<T>().FindAsync(id);
    }
}