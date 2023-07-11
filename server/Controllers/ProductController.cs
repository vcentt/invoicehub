using Microsoft.AspNetCore.Mvc;
using Services.Interfaces.IGenericService;
using server.Models;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IGenericService<Product> _productService;

    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, IGenericService<Product> productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> GetAllProducts(){
        try{
            return await _productService.GetAll();
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpPost]
    public async Task<Product> AddNewProduct([FromBody] Product newProduct){
        try{
            return await _productService.AddNew(newProduct);
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpPut]
    public async Task<Product> UpdateProduct([FromBody] Product ProductUpdated){
        try{
            return await _productService.Update(ProductUpdated);
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }

    [HttpDelete]
    public async Task<Product> DeleteProduct(int id) {
        try{
            return await _productService.Delete(id);
        }catch(Exception e){
            throw new Exception(e.ToString());
        }
    }
}
