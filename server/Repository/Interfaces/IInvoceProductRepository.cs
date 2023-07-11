
using server.Models;

namespace Repository.Interfaces.IInvoceProductRepository;

public interface IInvoceProductRepository {
    Task<IEnumerable<InvoceProduct>> GetAll();
    Task<IEnumerable<InvoceProduct>> GetInvoiceItemsByInvoiceId(int InvoceId);
    Task<InvoceProduct[]> AddNew(InvoceProduct[] newInvoceProduct);
    Task<InvoceProduct> UpdateInvoceProduct(InvoceProduct newInvoceProduct);
    Task Delete(long id);
}