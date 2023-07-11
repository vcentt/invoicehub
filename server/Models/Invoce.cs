using System;
using System.Collections.Generic;

namespace server.Models;

public partial class Invoce
{
    public int InvoceId { get; set; }

    public int? CustomerId { get; set; }

    public string? Status { get; set; }

    public DateOnly? Date { get; set; }

    public int? SubTotal { get; set; }

    public int? Itbis { get; set; }

    public int? Discount { get; set; }

    public int? Total { get; set; }

    // public virtual Customer? Customer { get; set; }

    // public virtual InvoceProduct? InvoceProduct { get; set; }

    // public virtual ICollection<InvoceProduct> InvoceProducts { get; set; } = new List<InvoceProduct>();
}
