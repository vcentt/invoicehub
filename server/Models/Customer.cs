using System;
using System.Collections.Generic;

namespace server.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    // public virtual ICollection<Invoce> Invoces { get; set; } = new List<Invoce>();
}
