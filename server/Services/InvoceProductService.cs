
using Repository.Interfaces.IInvoceProductRepository;
using Services.Interfaces.IInvoceProductService;
using server.Models;

namespace Services.InvoceProductService;

public class InvoceProductService : IInvoceProductService {
    private readonly IInvoceProductRepository _contextInvoceProduct;

    public InvoceProductService(IInvoceProductRepository contextInvoceProduct){
        _contextInvoceProduct = contextInvoceProduct;
    }

    public async Task<IEnumerable<InvoceProduct>> GetAll()
    {
        return await _contextInvoceProduct.GetAll();
    }

    public async Task<IEnumerable<InvoceProduct>> GetInvoiceItemsByInvoiceId(int InvoceId)
    {
        return await _contextInvoceProduct.GetInvoiceItemsByInvoiceId(InvoceId);
    }
    public async Task<InvoceProduct[]> AddNew(InvoceProduct[] newInvoceProduct)
    {
        return await _contextInvoceProduct.AddNew(newInvoceProduct);
    }

    public async Task Delete(long id)
    {
        await _contextInvoceProduct.Delete(id);
    }

    public async Task<InvoceProduct> UpdateInvoceProduct(InvoceProduct newInvoceProduct)
    {
        return await _contextInvoceProduct.UpdateInvoceProduct(newInvoceProduct);
    }
}