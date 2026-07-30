
namespace Sales.Domain.Entities;

public  class City
{
    public int CityId { get; set; }

    public string CityName { get; set; }

    public int CountryId { get; set; }

    public Country Country { get; set; }
    public ICollection<Customer> Customers { get; set; }
}