using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTTApi.Entities
{
    public class MTTContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public MTTContext(DbContextOptions<MTTContext> options)
            : base(options)
        {
        }

    }
}
