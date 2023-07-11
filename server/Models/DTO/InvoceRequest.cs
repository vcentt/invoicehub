using server.Models;

namespace Models.DTO.InvoceRequest;
public class InvoceRequest
{
    public required InvoceDTO Invoce { get; set; }
    public required InvoceProduct[] InvoceProducts { get; set; }
}
