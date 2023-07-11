using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.IInvoceService;
using server.Models;
using Models.DTO.InvoceRequest;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class InvoceController : ControllerBase
{
    private readonly IInvoceService _invoceService;

    private readonly ILogger<InvoceController> _logger;

    public InvoceController(ILogger<InvoceController> logger, IInvoceService invoceService)
    {
        _logger = logger;
        _invoceService = invoceService;
    }

    [HttpGet]
    public async Task<IEnumerable<InvoceClientDTO>> GetAllInvoces(){
        try{
            return await _invoceService.GetAll();
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IEnumerable<DetailInvoceDTO>> GetInvoceDetails(int id)
    {
        try{
            return await _invoceService.GetInvoceDetails(id);
        }
        catch (Exception e){
            throw new Exception(e.ToString());
        }
    }
    

    [HttpPost]
    public async Task<Invoce> AddNewInvoce([FromBody] InvoceRequest newInvoce){
        try{
            return await _invoceService.AddNew(newInvoce.Invoce, newInvoce.InvoceProducts);
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpPut]
    public async Task<Invoce> UpdateInvoce([FromBody] Invoce InvoceUpdated){
        try{
            return await _invoceService.Update(InvoceUpdated);
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpDelete]
    public async Task<Invoce> DeleteInvoce(long id) {
        try{
            return await _invoceService.Delete(id);
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }
}
