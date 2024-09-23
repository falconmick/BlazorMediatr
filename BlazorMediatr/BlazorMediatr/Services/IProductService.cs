using BlazorMediatr.Contract.Models;
using Bogus;

namespace BlazorMediatr.Service;

public interface IProductService
{
     Task<List<Product>> GetProducts(string location);
}

public class ProductService : IProductService
{
     public Task<List<Product>> GetProducts(string location)
     {
          var faker = new Faker();
          return Task.FromResult(new List<Product>
          {
               new Product(location + " - " + faker.Vehicle.Model(), faker.Random.Number(1000, 10000)),
               new Product(location + " - " + faker.Vehicle.Model(), faker.Random.Number(1000, 10000)),
          });
     }
}