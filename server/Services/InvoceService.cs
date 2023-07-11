
using Repository.Interfaces.IGenericRepository;
using Repository.Interfaces.IInvoceRepository;
using Services.Interfaces.IInvoceService;
using server.Models;
using Repository.Interfaces.IInvoceProductRepository;

namespace Services.InvoceService;

public class InvoceService : IInvoceService
{
    private readonly IInvoceRepository _contextInvoce;
    private readonly IGenericRepository<Product> _contextProducts;
    private readonly IInvoceProductRepository _contextInvoceRepository;

    public InvoceService(IInvoceRepository contextInvoce, IGenericRepository<Product> contextProducts, IInvoceProductRepository contextInvoceRepository)
    {
        _contextInvoce = contextInvoce;
        _contextProducts = contextProducts;
        _contextInvoceRepository = contextInvoceRepository;
    }
    public async Task<IEnumerable<InvoceClientDTO>> GetAll()
    {
        return await _contextInvoce.GetAll();
    }

    public async Task<IEnumerable<DetailInvoceDTO>> GetInvoceDetails(int id){
        return await _contextInvoce.GetInvoceDetails(id);
    }

    public async Task<Invoce> AddNew(InvoceDTO newInvoce, InvoceProduct[] newInvoceProduct)
    {
        var newInvoceFix = new Invoce
        {
            InvoceId = newInvoce.InvoceId,
            CustomerId = newInvoce.CustomerId,
            Status = newInvoce.Status,
            Date = DateOnly.Parse(newInvoce.Date!),
            SubTotal = newInvoce.SubTotal,
            Itbis = newInvoce.Itbis,
            Discount = newInvoce.Discount,
            Total = newInvoce.Total
        };
        await _contextInvoce.AddNew(newInvoceFix);
        Console.WriteLine(newInvoceFix.InvoceId);

        foreach (InvoceProduct products in newInvoceProduct)
        {
            products.InvoceId = newInvoceFix.InvoceId;
        }

        await _contextInvoceRepository.AddNew(newInvoceProduct);

        await UpdateInvoce(newInvoceFix);

        return newInvoceFix;
    }

    public async Task<Invoce> Update(Invoce InvoceUpdated)
    {
        return await _contextInvoce.Update(InvoceUpdated);
    }
    public async Task<Invoce> Delete(long id)
    {
        return await _contextInvoce.Delete(id);
    }

    public async Task UpdateInvoce(Invoce newInvoce)
    {
        List<InvoceProduct> allProducts = (List<InvoceProduct>)await _contextInvoceRepository.GetInvoiceItemsByInvoiceId(newInvoce.InvoceId);

        int subTotal = 0;
        int discount = 0;

        foreach (InvoceProduct product in allProducts)
        {
            var getDetailProduct = await _contextProducts.GetById(product.ProductId ?? 0);
            subTotal += getDetailProduct.Price * product.Quantity;
            discount += (subTotal * (product.Discount / 100));
        }

        int itbis = (int)(subTotal * 0.18);
        int total = subTotal + itbis - discount;

        newInvoce.SubTotal = subTotal;
        newInvoce.Itbis = itbis;
        newInvoce.Discount = discount;
        newInvoce.Total = total;
        await _contextInvoce.Update(newInvoce);
    }


}