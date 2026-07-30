 
using System;
using System.Collections.Generic;

namespace Sales.Domain.Entities;

public  class OrderDetail
{
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal TotalPrice { get; set; }

    public ICollection<Product> Products { get; set; }
}