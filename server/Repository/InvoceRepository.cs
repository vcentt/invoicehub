
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.IInvoceRepository;
using server.Models;

namespace Repository.InvoceRepository;

public class InvoceRepository : IInvoceRepository
{
    public readonly InvocehubContext _context;

    public InvoceRepository(InvocehubContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InvoceClientDTO>> GetAll()
    {
        var query = from invoice in _context.Invoces
                    join customer in _context.Customers on invoice.CustomerId equals customer.CustomerId
                    select new InvoceClientDTO
                    {
                        invoceId = invoice.InvoceId,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Status = invoice.Status,
                        Date = invoice.Date,
                        Subtotal = invoice.SubTotal,
                        Itbis = invoice.Itbis,
                        Discount = invoice.Discount,
                        Total = invoice.Total
                    };

        return await query.ToListAsync();
    }
    public async Task<IEnumerable<DetailInvoceDTO>> GetInvoceDetails(int id)
    {
        var query = from invoice in _context.Invoces
                    join invoiceProduct in _context.InvoceProducts on invoice.InvoceId equals invoiceProduct.InvoceId
                    join customer in _context.Customers on invoice.CustomerId equals customer.CustomerId
                    join product in _context.Products on invoiceProduct.ProductId equals product.ProductId
                    where invoice.InvoceId == id
                    select new
                    {
                        InvoceId = invoice.InvoceId,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Status = invoice.Status,
                        Date = invoice.Date,
                        ProductName = product.ProductName,
                        Quantity = invoiceProduct.Quantity,
                        SubTotal = invoice.SubTotal,
                        ITBIS = invoice.Itbis,
                        Discount = invoice.Discount,
                        Total = invoice.Total,
                        Price = product.Price
                    };

        var groupedResult = query.GroupBy(x => new
        {
            x.InvoceId,
            x.FirstName,
            x.LastName,
            x.Status,
            x.Date,
            x.SubTotal,
            x.ITBIS,
            x.Discount,
            x.Total
        }).Select(g => new DetailInvoceDTO
        {
            InvoceId = g.Key.InvoceId,
            FirstName = g.Key.FirstName,
            LastName = g.Key.LastName,
            Status = g.Key.Status,
            Date = g.Key.Date,
            SubTotal = g.Key.SubTotal,
            ITBIS = g.Key.ITBIS,
            Discount = g.Key.Discount,
            Total = g.Key.Total,
            Products = g.Select(p => new ProductDTO
            {
                ProductName = p.ProductName,
                Quantity = p.Quantity,
                Price = p.Price
            }).ToList()
        });

        return await groupedResult.ToListAsync();


    }
    public async Task<Invoce> AddNew(Invoce newInvoce)
    {

        _context.Add(newInvoce);
        await _context.SaveChangesAsync();
        return newInvoce;
    }

    public async Task<Invoce> Update(Invoce InvoceUpdated)
    {
        _context.Entry(InvoceUpdated).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return InvoceUpdated;
    }
    public async Task<Invoce> Delete(long id)
    {
        var queryToDeleteAllProductWithSameInvoce = from n in _context.InvoceProducts
                                                    where n.InvoceId == id
                                                    select n;
        _context.InvoceProducts.RemoveRange(queryToDeleteAllProductWithSameInvoce);
        
        var query = from n in _context.Invoces
                    where n.InvoceId == id
                    select n;

        var invoce = await query.FirstAsync();
        _context.Remove(invoce);
        await _context.SaveChangesAsync();
        return invoce;
    }

}