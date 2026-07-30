
using System;
using System.Collections.Generic;

namespace Sales.Domain.Entities;

public  class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; }

    public ICollection<City> Cities { get; set; }
    public ICollection<Customer> Customers { get; set; }

}