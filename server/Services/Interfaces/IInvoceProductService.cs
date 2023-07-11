
using server.Models;

namespace Services.Interfaces.IInvoceProductService;

public interface IInvoceProductService {
    Task<IEnumerable<InvoceProduct>> GetAll();
    Task<IEnumerable<InvoceProduct>> GetInvoiceItemsByInvoiceId(int InvoceId);
    Task<InvoceProduct[]> AddNew(InvoceProduct[] newInvoceProduct);
    Task<InvoceProduct> UpdateInvoceProduct(InvoceProduct newInvoceProduct);
    Task Delete(long id);
}