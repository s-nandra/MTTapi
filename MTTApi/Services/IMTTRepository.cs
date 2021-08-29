using MTTApi.Entities;
using MTTApi.Models;
using System.Collections.Generic;

namespace MTTApi.Services
{
    public interface IMTTRepository
    {
        bool ProductExists(int productId);

        IEnumerable<Product> GetProducts();


        IEnumerable<Product> GetFeaturedProducts();

        Product GetProduct(int productId);
        IEnumerable<Product> GetProductsByCategory(string category);
    }
}
