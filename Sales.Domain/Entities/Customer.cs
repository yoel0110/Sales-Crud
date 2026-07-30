
using System;
using System.Collections.Generic;

namespace Sales.Domain.Entities;

public  class Customer
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public int CountryId { get; set; }

    public int CityId { get; set; }

    public ICollection<Order> Orders { get; set; }
    public Country Country { get; set; }
    public City City { get; set; }
}