public class DetailInvoceDTO
{   
    public int? InvoceId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Status { get; set; }
    public DateOnly? Date { get; set; }
    public int? SubTotal { get; set; }
    public int? ITBIS { get; set; }
    public int? Discount { get; set; }
    public int? Total { get; set; }
    public List<ProductDTO>? Products { get; set; }
}
