using System;
using System.Collections.Generic;

namespace server.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Description { get; set; }

    public int Price { get; set; }

    // public virtual ICollection<InvoceProduct> InvoceProducts { get; set; } = new List<InvoceProduct>();
}
