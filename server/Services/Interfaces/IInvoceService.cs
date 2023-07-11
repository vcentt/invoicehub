
using server.Models;

namespace Services.Interfaces.IInvoceService;

public interface IInvoceService {
    Task<IEnumerable<InvoceClientDTO>> GetAll();
    Task<IEnumerable<DetailInvoceDTO>> GetInvoceDetails(int id);
    Task<Invoce> AddNew(InvoceDTO newInvoce, InvoceProduct[] newInvoceProduct);
    Task<Invoce> Update(Invoce InvoceUpdated);
    Task<Invoce> Delete(long id);
}