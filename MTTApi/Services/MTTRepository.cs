using Microsoft.EntityFrameworkCore;
using MTTApi.Entities;
using MTTApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MTTApi.Services
{
    public class MTTRepository : IMTTRepository
    {
        private MTTContext _context;

        public MTTRepository(MTTContext context)
        {
            _context = context; 
        }


        public IEnumerable<Product> GetFeaturedProducts()
        {
            return _context.Products.Where(x => x.IsFeatured == true)
             .OrderBy(a => a.Sku)
             .ToList();
        }

        public Product GetProduct(int productId)
        {
            return _context.Products.Where(c => c.Id == productId).FirstOrDefault();
        }


        public bool ProductExists(int productId)
        {
            return _context.Products.Any(p => p.Id == productId);
        }

        IEnumerable<Product> IMTTRepository.GetFeaturedProducts()
        {
            return _context.Products
             .Include(a => a.Category)
             .Where(a=>a.IsFeatured==true)
             .OrderBy(a => a.Name)
             .ToList();
        }


        public IEnumerable<Product> GetProducts()
        {
            return _context.Products
                .Include(a => a.Category)
                .OrderBy(a => a.Name)
                .ToList();
        }


        IEnumerable<Product> IMTTRepository.GetProductsByCategory(string categoryName)
        {
            return _context.Products.Where(x => x.Category.Name == categoryName)
             .OrderBy(a => a.Sku)
             .ToList();  
        }
    }
}
