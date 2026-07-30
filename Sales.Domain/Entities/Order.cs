using System;
using System.Collections.Generic;

namespace Sales.Domain.Entities;

public  class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string Status { get; set; }
}