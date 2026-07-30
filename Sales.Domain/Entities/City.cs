
using System;
using System.Collections.Generic;

namespace Sales.Domain.Entities;

public  class City
{
    public int CityId { get; set; }

    public string CityName { get; set; }

    public int CountryId { get; set; }
}