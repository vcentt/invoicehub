
using server.Models;

namespace Repository.Interfaces.IInvoceRepository;

public interface IInvoceRepository {
    Task<IEnumerable<InvoceClientDTO>> GetAll();
    Task<IEnumerable<DetailInvoceDTO>> GetInvoceDetails(int id);
    Task<Invoce> AddNew(Invoce newInvoce);
    Task<Invoce> Update(Invoce InvoceUpdated);
    Task<Invoce> Delete(long id);
}