
namespace server.Models;

public partial class InvoceDTO
{
    public int InvoceId { get; set; }

    public int? CustomerId { get; set; }

    public string? Status { get; set; }

    public string? Date { get; set; }

    public int? SubTotal { get; set; }

    public int? Itbis { get; set; }

    public int? Discount { get; set; }

    public int? Total { get; set; }
}
