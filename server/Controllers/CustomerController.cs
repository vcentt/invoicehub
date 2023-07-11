using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.IGenericService;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IGenericService<Customer> _customerService;

    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger, IGenericService<Customer> customerService)
    {
        _logger = logger;
        _customerService = customerService;
    }

    [HttpGet]
    public async Task<IEnumerable<Customer>> GetAllCustomers(){
        try{
            return await _customerService.GetAll();
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpPost]
    public async Task<Customer> AddNewCustomer([FromBody] Customer newCustomer){
        try{
            return await _customerService.AddNew(newCustomer);
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpPut]
    public async Task<Customer> UpdateCustomer([FromBody] Customer CustomerUpdated){
        try{
            return await _customerService.Update(CustomerUpdated);
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpDelete]
    public async Task<Customer> DeleteCustomer(int id) {
        try{
            return await _customerService.Delete(id);
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }
}
