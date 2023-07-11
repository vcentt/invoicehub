using System;
using System.Collections.Generic;

namespace server.Models;

public partial class InvoceProduct
{
    public int InvoceProductId { get; set; }
    public int? InvoceId { get; set; }
    public int? ProductId { get; set; }
    public int Quantity { get; set; }
    public int Discount { get; set; }

    // public virtual Invoce? Invoce { get; set; }

    // public virtual ICollection<Invoce> Invoces { get; set; } = new List<Invoce>();

    // public virtual Product? Product { get; set; }
}
