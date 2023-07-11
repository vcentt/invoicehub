using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.IInvoceProductService;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoceProductController : ControllerBase
{
    private readonly IInvoceProductService _invoceProductService;

    private readonly ILogger<InvoceProductController> _logger;

    public InvoceProductController(ILogger<InvoceProductController> logger, IInvoceProductService invoceProductService)
    {
        _logger = logger;
        _invoceProductService = invoceProductService;
    }

    [HttpGet]
    public async Task<IEnumerable<InvoceProduct>> GetAllInvoces(){
        try{
            return await _invoceProductService.GetAll();
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IEnumerable<InvoceProduct>> GetInvoiceProductsByInvoiceId(int InvoceId){
        try{
            return await _invoceProductService.GetInvoiceItemsByInvoiceId(InvoceId);
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpPut]
    public async Task<InvoceProduct> UpdateInvoceProduct([FromBody] InvoceProduct newInvoceProduct){
        try{
            return await _invoceProductService.UpdateInvoceProduct(newInvoceProduct);
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpDelete]
    public async Task DeleteInvoceProduct(long id) {
        try{
            await _invoceProductService.Delete(id);
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }
}
