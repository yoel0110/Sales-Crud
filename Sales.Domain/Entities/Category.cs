
using System;
using System.Collections.Generic;

namespace Sales.Domain.Entities;

public class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public ICollection<Product> Products { get; set; }
}