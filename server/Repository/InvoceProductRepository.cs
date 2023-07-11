using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.IInvoceProductRepository;
using server.Models;

namespace Repository.InvoceProductRepository;

public class InvoceProductRepository : IInvoceProductRepository {
    private readonly InvocehubContext _context;
    public InvoceProductRepository(InvocehubContext context){
        _context = context;
    }

    public async Task<IEnumerable<InvoceProduct>> GetAll()
    {
        var query = from n in _context.InvoceProducts
                    select n;
        
        return await query.ToListAsync();
    }

    public async Task<IEnumerable<InvoceProduct>> GetInvoiceItemsByInvoiceId(int InvoceId)
    {
        var query = from n in _context.InvoceProducts
                    where n.InvoceId == InvoceId
                    select n;
        return await query.ToListAsync();
    }
    public async Task<InvoceProduct[]> AddNew(InvoceProduct[] newInvoceProduct)
    {
        _context.InvoceProducts.AddRange(newInvoceProduct);
        await _context.SaveChangesAsync();
        return newInvoceProduct;
    }

    public async Task<InvoceProduct> UpdateInvoceProduct(InvoceProduct newInvoceProduct)
    {
        _context.Entry(newInvoceProduct).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return newInvoceProduct;
    }

    public async Task Delete(long id)
    {
        var queryToDeleteAllProductWithSameInvoce = from n in _context.InvoceProducts
                                                    where n.InvoceId == id
                                                    select n;
        _context.InvoceProducts.RemoveRange(queryToDeleteAllProductWithSameInvoce);
        await _context.SaveChangesAsync();
        return;
    }

}